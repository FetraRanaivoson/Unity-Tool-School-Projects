using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyWindow : EditorWindow
{
    private static EditorWindow window;
    private Color[] colors = {Color.red, Color.green, Color.blue};
    private Color save;
    
    [MenuItem("Setting/Open window")]
    public static void OpenWindow()
    {
        window = GetWindow<MyWindow>("My window");
    }
    
    public void OnEnable()
    {
        
    }

    public void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        for (int row = 0; row < colors.Length; row++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int col = 0; col < colors.Length; col++)
            {
                DrawCol(row, col);
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
        GUI.color = save;
    }

    private void DrawCol(int row, int col)
    {
        save = GUI.color;
        GUI.color = colors[col];
        GUILayout.Box(GUIContent.none, GUILayout.ExpandWidth(true),
            GUILayout.ExpandHeight(true));
    }
}
