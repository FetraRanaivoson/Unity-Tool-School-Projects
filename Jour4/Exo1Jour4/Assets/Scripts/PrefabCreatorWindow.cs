using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PrefabCreatorWindow : EditorWindow
{
    private static EditorWindow _enemyToolWindow;
    [MenuItem("Enemy/Create enemy...")]
    public static void OpenEnemyCreationWindow()
    {
        _enemyToolWindow = GetWindow<PrefabCreatorWindow>("Enemy window tool");
    }

    
    private string[] _prefabName = new string[3];
    private MainScript _mainScript;
    private void OnEnable()
    {
        _prefabName = new[] {"Enemy Type 1", "Enemy Type 2", "Enemy Type 3"};
        _mainScript = FindObjectOfType<MainScript>();
    }

    private int _selectedIndex;
    private bool _prefabCreated = true;
    private void OnGUI()
    {
        _selectedIndex = EditorGUILayout.Popup("Enemy type", _selectedIndex, _prefabName);
        float buttonWidth = position.width / 5;
        float buttonHeight = position.height / 10;
        float buttonPosX = position.width / 2 - buttonWidth / 2;
        Rect buttonPosition = new Rect(buttonPosX, 30, buttonWidth, buttonHeight);
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
            if (GUI.Button(buttonPosition,"Swap"))
            {
                _mainScript.SwapInstancedPrefabBy(_selectedIndex);
                _prefabCreated = true;
            }
        }
        
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
