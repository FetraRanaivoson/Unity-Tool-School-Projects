using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class ColorWindow : EditorWindow
{
    private static EditorWindow colorToolWindow;
    private Color[] colors = {Color.red, Color.white, Color.white, Color.white, Color.white};


    [MenuItem("CustomTools/Color Tools")]
    public static void OpenWindow()
    {
        colorToolWindow = GetWindow<ColorWindow>("ColorToolWindow");
    }

    public void OnEnable()
    {
    }

    Color paintColor = Color.white;
    Color eraseColor = Color.white;
    Color boxRectColorForPaint = Color.green;
    Color boxRectColorForErase = Color.white;
    private void OnGUI()
    {
        //string[] selStrings = {"radio1", "radio2", "radio3"};
        //GUILayout.Toolbar(0, selStrings, GUIStyle.none);
        //GUI.color = Color.red;

        //GUILayout.BeginHorizontal();
        //TOOLBOX
        SetColors(Color.black, Color.white);
        Vector2 toolBarSize = new Vector2(position.width / 3, position.height);
        GUILayout.BeginArea(new Rect(0, 0, toolBarSize.x, toolBarSize.y));
            AddSpace(10);
            AddLabel("ToolBar", EditorStyles.boldLabel);
            AddSpace(10);
            paintColor = EditorGUILayout.ColorField("Paint color", paintColor);
            eraseColor = EditorGUILayout.ColorField("Erase Color", eraseColor);
            SetColors(Color.white, Color.white);
            GUI.Button(new Rect(0, 75, toolBarSize.x, 20), "Fill All");
        GUILayout.EndArea();

        //PAINT AREA
        SetColors(Color.black, Color.white);
        //GUILayout.BeginVertical();
        //GUILayout.BeginArea(new Rect(toolBarSize.x + 10, 0, position.width - toolBarSize.x - 20, position.height - 10));
        //AddSpace(10);
        Rect boxRect = new Rect(new Vector2(toolBarSize.x + 10, 10), new Vector2(position.width - toolBarSize.x - 20, position.height - 20));
        Event e = Event.current;
        if (e.type == EventType.MouseDown)
        {
            if (boxRect.Contains(e.mousePosition) && e.button == 0)
            {
                Debug.Log("Box clicked");
                boxRectColorForPaint = paintColor;
                boxRectColorForErase = eraseColor;
            }
            e.Use();
        }
        if (eraseColor != Color.white)
            GUI.backgroundColor = boxRectColorForErase;
        else
            GUI.backgroundColor = boxRectColorForPaint;

        GUI.Box(boxRect, GUIContent.none);
        
        //GUILayout.Box(new GUIContent(GUIContent.none), GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
        //GUILayout.EndArea();
        //GUILayout.EndVertical();
        //GUILayout.EndHorizontal();
        
        // EditorGUILayout.BeginVertical();
        // for (int row = 0; row < colors.Length; row++)
        // {
        //     EditorGUILayout.BeginHorizontal();
        //     for (int col = 0; col < colors.Length; col++)
        //     {
        //         DrawCol(row, col);
        //     }
        //     EditorGUILayout.EndHorizontal();
        // }
        // EditorGUILayout.EndVertical();
    }

    private void SetColors(Color background, Color font)
    {
        GUI.backgroundColor = background;
        GUI.color = font;
    }

    private void AddSpace(int pixel)
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