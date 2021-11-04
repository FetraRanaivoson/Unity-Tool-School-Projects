using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(MainScript))]
public class MainScriptEditor : Editor
{
    private MainScript _mainScript;
    private void OnEnable()
    {
        _mainScript = target as MainScript;
    }

    public override void OnInspectorGUI()
    {
        Rect area = GUILayoutUtility.GetRect(EditorGUIUtility.currentViewWidth, 4 * EditorGUIUtility.singleLineHeight);
        
        GUI.Box(area, GUIContent.none);

        if (GUI.Button(
            new Rect(EditorGUIUtility.currentViewWidth / 2 - EditorGUIUtility.currentViewWidth / 4, 10,
                EditorGUIUtility.currentViewWidth / 2, 25), "Save"))
        {
            //_mainScript.player.SerializePosition();
        }

        if (GUI.Button(
            new Rect(EditorGUIUtility.currentViewWidth / 2 - EditorGUIUtility.currentViewWidth / 4, 40,
                EditorGUIUtility.currentViewWidth / 2, 25), "Load"))
        {
            //_mainScript.player.DeserializePosition();
        }

    }
    
  
}
