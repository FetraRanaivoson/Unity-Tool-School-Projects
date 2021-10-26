using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerS))]
public class PlayerE : Editor
{
    private PlayerS playerS;
    private GameObject go;
    public void OnEnable()
    {
        playerS = target as PlayerS;
        //Debug.Log("OnEnable");
    }

    public void OnDisable()
    {
        //Debug.Log("OnDisable");
    }

    public void OnDestroy()
    {
        //Debug.Log("OnDestroy");
    }

    public void OnValidate()
    {
        //Debug.Log("OnValidate");
    }

    public override void OnInspectorGUI()
    {
        //Debug.Log("OnInspectorGUI");
        //base.OnInspectorGUI();
        //DrawDefaultInspector();

        if (GUILayout.Button("coucou"))
        {
            Debug.Log("Button clicked");
        }

        //Label, drag and drop
        playerS.name = GUILayout.TextField(playerS.name);
        GUILayout.Label(playerS.name);
        go = EditorGUILayout.ObjectField(go, typeof(GameObject), true) as GameObject;

        
        Rect dropZone = GUILayoutUtility.GetRect( EditorGUIUtility.currentViewWidth, 5* EditorGUIUtility.singleLineHeight);
        GUI.Box(dropZone, "Drop zone");
        
        
        //Events: keydown, drag and drop
        Event e = Event.current;
        if (e.type == EventType.KeyDown)
        {
            //Debug.Log("Event: " + e.keyCode);
            //e.Use();
        }
       
        if (e.type == EventType.DragUpdated)
        {
            Debug.Log("Drag updated");
            DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
            e.Use();
        }
        if (e.type == EventType.DragPerform)
        {
            Debug.Log("Drag performed");
            DragAndDrop.AcceptDrag();
            foreach (var obj in DragAndDrop.objectReferences)
            {
                GameObject gameObject = obj as GameObject;
                if (gameObject != null)
                {
                    Debug.Log("Drag accepted");
                    go = gameObject;
                }
            }
            e.Use();
        }
    }

    public void OnSceneGUI()
    {
        //SceneView.currentDrawingSceneView.in2DMode = true;
        
        Handles.color = Color.red;
        Handles.DrawWireCube(playerS.transform.position, new Vector3(3,3,3));
        
        Handles.BeginGUI();
        EditorGUILayout.LabelField("Super Cube");
        GUILayout.Button("Button");
        Handles.EndGUI();
    }
}
