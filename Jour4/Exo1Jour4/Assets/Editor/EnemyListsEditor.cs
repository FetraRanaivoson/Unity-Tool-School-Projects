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
    private int _selectedIndex;

    private void OnEnable()
    {
        _mainScript = target as MainScript;
        _prefabName = new[] {"Enemy Type 1", "Enemy Type 2", "Enemy Type 3"};
    }

    private bool _prefabCreated = true;

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical();
        _selectedIndex = EditorGUILayout.Popup("Enemy type", _selectedIndex, _prefabName);
        Rect buttonPosition = new Rect(150, 50, 100, 20);
        if (_prefabCreated)
        {
            if (GUI.Button(buttonPosition, "Create"))
            {
                _mainScript.InstantiatePrefab(_selectedIndex);
                _prefabCreated = false;
            }
        }
        else
        {
            if (GUI.Button(buttonPosition, "Swap"))
            {
                _mainScript.SwapInstancedPrefabBy(_selectedIndex);
                _prefabCreated = true;
            }
        }

        EditorGUILayout.EndVertical();

        Rect area = GUILayoutUtility.GetRect(EditorGUIUtility.currentViewWidth, 4 * EditorGUIUtility.singleLineHeight);
        GUI.Box(area, GUIContent.none);

        //Update to create button if user clicks outside the editor
        Event e = Event.current;
        if (e.type == EventType.MouseDown)
        {
            if (!buttonPosition.Contains(e.mousePosition))
            {
                _prefabCreated = true;
            }
            e.Use();
        }
    }
}