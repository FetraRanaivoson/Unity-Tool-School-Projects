using System;
using System.Collections;
using System.Collections.Generic;
using Codice.Client.BaseCommands.BranchExplorer;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(MainScript))]
public class EnemyListsEditor : Editor
{
    private MainScript _mainScript;
    private string[] _prefabName = new string[3];
    private int selectedIndex;

    private void OnEnable()
    {
        _mainScript = target as MainScript;
        _prefabName = new[] {"Enemy Type 1", "Enemy Type 2", "Enemy Type 3"};
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical();
                selectedIndex = EditorGUILayout.Popup("Enemy type", selectedIndex, _prefabName);
                if (GUI.Button(new Rect(150, 50, 100, 20), "Create"))
                {
                    _mainScript.InstantiatePrefab(selectedIndex);
                }
        EditorGUILayout.EndVertical();
        
        Rect area = GUILayoutUtility.GetRect(EditorGUIUtility.currentViewWidth, 4 * EditorGUIUtility.singleLineHeight);
        GUI.Box(area, GUIContent.none);
    }
}
