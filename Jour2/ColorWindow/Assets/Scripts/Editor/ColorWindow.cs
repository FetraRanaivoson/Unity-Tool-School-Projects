using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class ColorWindow : EditorWindow
{
    private static EditorWindow _colorToolWindow;
    private GameObject _targetGameObject;
    private Texture2D _texture;
    

    [MenuItem("CustomTools/Color Tools")]
    public static void OpenWindow()
    {
        _colorToolWindow = GetWindow<ColorWindow>("ColorToolWindow");
    }

    private void OnEnable()
    {
        InitBoxes();
        _texture = EditorGUIUtility.whiteTexture;
    }
    private void InitBoxes()
    {
        for (int row = 0; row < _nbRow; row++)
        {
            for (int col = 0; col < _nbCol; col++)
            {
                boxesColor[row, col] = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            }
        }
    }

    Color _paintColor = Color.white;
    Color _eraseColor = Color.white;
    static int _nbRow = 16;
    static int _nbCol = 18;
    Rect[,] boxes = new Rect[_nbRow, _nbCol];
    Color[,] boxesColor = new Color[_nbRow, _nbCol];
    private Texture2D [,] _savedTextures = new Texture2D[_nbRow,_nbCol];

    private void OnGUI()
    {
        //TOOLBOX
        SetColors(Color.white, Color.white);
        Vector2 toolBarSize = new Vector2(position.width / 3, position.height);
        GUILayout.BeginArea(new Rect(0, 0, toolBarSize.x, toolBarSize.y));
            AddSpace(10);
            AddLabel("ToolBar", EditorStyles.boldLabel);
            AddSpace(10);
            _paintColor = EditorGUILayout.ColorField("Paint color", _paintColor);
            _eraseColor = EditorGUILayout.ColorField("Erase Color", _eraseColor);
            
            EditorGUI.BeginChangeCheck();
            _nbRow = EditorGUILayout.IntField("Row", Mathf.Max(2, _nbRow));
            _nbCol = EditorGUILayout.IntField("Column", Mathf.Max(2, _nbCol));
            if (EditorGUI.EndChangeCheck())
            {
                boxes = new Rect[_nbRow, _nbCol];
                boxesColor = new Color[_nbRow, _nbCol];
                for (int row = 0; row < _nbRow; row++)
                {
                    for (int col = 0; col < _nbCol; col++)
                    {
                        boxesColor[row, col] = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                    }
                }
            }
            
            if (GUI.Button(new Rect(0, 120, toolBarSize.x, 20), "Fill All"))
            {
                for (int row = 0; row < _nbRow; row++)
                {
                    for (int col = 0; col < _nbCol; col++)
                    {
                        boxesColor[row, col] = _paintColor;
                    }
                }
            }
            AddSpace( toolBarSize.y - 170);
            EditorGUILayout.BeginHorizontal();
                AddLabel("Output renderer", EditorStyles.label);
                _targetGameObject = EditorGUILayout.ObjectField( _targetGameObject, typeof(GameObject), true) as GameObject;
            EditorGUILayout.EndHorizontal();
            if (GUI.Button(new Rect(0, toolBarSize.y - 25, toolBarSize.x, 20), "Save to object"))
            {
                SaveTextures();
            }
        GUILayout.EndArea();

        //PAINT AREA
        Vector2 paintPosition = new Vector2(toolBarSize.x + 10, 0);
        float boxW = (position.width - paintPosition.x) / _nbCol;
        float boxH = position.height / _nbRow;
        GUILayout.BeginArea(new Rect(paintPosition.x, paintPosition.y, position.width - toolBarSize.x, position.height));
        for (int row = 0; row < _nbRow; row++)
        {
            for (int col = 0; col < _nbCol; col++)
            {
                boxes[row, col] = new Rect(new Vector2(col * boxW, row * boxH), new Vector2(boxW, boxH));
                GUI.color = boxesColor[row, col];
                GUI.DrawTexture(boxes[row, col], _texture);
                //GUI.Box(boxes[row, col], GUIContent.none);
            }
        }
        GUILayout.EndArea();

        //MANAGE EVENTS
        Event e = Event.current;
        if (e.type == EventType.MouseDrag || e.type == EventType.MouseDown)
        {
            for (int row = 0; row < _nbRow; row++)
            {
                for (int col = 0; col < _nbCol; col++)
                {
                    if (boxes[row, col].Contains(e.mousePosition - paintPosition ) && e.button == 0)
                    {
                        boxesColor[row, col] = _paintColor;
                    }
                    else if (boxes[row, col].Contains(e.mousePosition - paintPosition ) && e.button == 1)
                    {
                        boxesColor[row, col] = _eraseColor;
                    }
                    e.Use();
                }
            }
        }
    }

    private void SaveTextures()
    {
       // int mipCount = Mathf.Min(_nbRow*_nbCol, _texture.mipmapCount);
       int mipCount = Mathf.Min(_nbRow*_nbCol, _texture.mipmapCount);
        int currentRow = 0;
        // tint each mip level
        for (int mip = 0; mip < mipCount; mip++)
        {
            Color[] cols = _texture.GetPixels(mip);
            for (int i = 0; i < cols.Length; i++)
            {
                if (i < _nbCol)
                {
                    //0:00 1:01 2:02 3:03 .. 
                    cols[i] = boxesColor[currentRow,i];  
                }
                else
                {
                    currentRow++;
                }
            }
            _texture.SetPixels(cols, mip);
        }

        byte[] bytes = _texture.EncodeToPNG();
        var dirPath = Application.dataPath + "/Resources";
        if (!System.IO.Directory.Exists(dirPath))
        {
            System.IO.Directory.CreateDirectory(dirPath);
        }
        System.IO.File.WriteAllBytes(dirPath + "/Texture" + ".png", bytes);
        Debug.Log(bytes.Length / 1024 + "Kb was saved as: " + dirPath);
        #if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
        #endif
        Texture2D loadedTexture2D = Resources.Load<Texture2D>("Texture");
        _targetGameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", loadedTexture2D);
    }

    private void SetColors(Color background, Color font)
    {
        GUI.backgroundColor = background;
        GUI.color = font;
    }
    private void AddSpace(float pixel)
    {
        GUILayout.Space(pixel);
    }
    private void AddLabel(string text, GUIStyle style)
    {
        GUILayout.Label(text, style);
    }
    private void DrawCol(int row, int col)
    {
        GUI.color = Color.white;
        GUILayout.Box(new GUIContent(GUIContent.none), GUILayout.ExpandWidth(true),
            GUILayout.ExpandHeight(true));
    }
}