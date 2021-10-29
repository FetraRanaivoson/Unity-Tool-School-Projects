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

    [MenuItem("CustomTools/Color Tools")]
    public static void OpenWindow()
    {
        _colorToolWindow = GetWindow<ColorWindow>("ColorToolWindow");
    }

    private void OnEnable()
    {
        InitBoxes();
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
            _nbRow = EditorGUILayout.IntField("Row", _nbRow);
            _nbCol = EditorGUILayout.IntField("Column", _nbCol);
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
                Debug.Log("Texture saved!");
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
                GUI.backgroundColor = boxesColor[row, col];
                GUI.Box(boxes[row, col], GUIContent.none);
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