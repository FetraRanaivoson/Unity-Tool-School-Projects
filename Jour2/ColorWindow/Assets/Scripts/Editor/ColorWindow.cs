using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;

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

    private void OnGUI()
    {
        //string[] selStrings = {"radio1", "radio2", "radio3"};
        //GUILayout.Toolbar(0, selStrings, GUIStyle.none);
        //GUI.color = Color.red;
        
        GUILayout.BeginArea(new Rect(0,0, 250,250), GUIContent.none);
        
        GUILayout.Box(new GUIContent(GUIContent.none), GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
        GUI.backgroundColor = Color.cyan;
        GUI.color = Color.red;
        GUILayout.Space(10);
        GUILayout.Label("ToolBar", EditorStyles.boldLabel);
        GUILayout.Space(10);
        GUILayout.Label("Paint Color", EditorStyles.label);
        GUILayout.Label("Erase Color", EditorStyles.label);
        
        GUILayout.EndArea();
        
        //GUILayout.BeginArea(new Rect(0,0, 150,350), GUIContent.none);
        //GUILayout.Button("ok", GUILayout.ExpandHeight(true));
        //GUILayout.EndArea();
        

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

    private void DrawCol(int row, int col)
    {
        GUI.color = Color.white;
        GUILayout.Box(new GUIContent(GUIContent.none), GUILayout.ExpandWidth(true),
            GUILayout.ExpandHeight(true));
    }
}
