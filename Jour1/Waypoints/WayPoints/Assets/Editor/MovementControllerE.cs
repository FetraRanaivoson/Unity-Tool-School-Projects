using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

[CustomEditor(typeof(MovementControllerS))]
public class MovementControllerE : Editor
{
    private MovementControllerS movementControllerScript;
    private List<GameObject> WayPoints;
    private GameObject go;
    
    public void OnEnable()
    {
        movementControllerScript = target as MovementControllerS;
        WayPoints = movementControllerScript.wayPoints; //
    }

    public void OnDisable()
    {
    }

    public void OnDestroy()
    {
    }

    public void OnValidate()
    {
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        if (GUI.changed)
            EditorUtility.SetDirty(target);
        
        //Debug.Log("OnInspectorGUI");
        //Display movement parameter
        //GUILayout.Label("Movement Controller Params");
        EditorGUILayout.LabelField("Movement Controller Params");
        movementControllerScript.Speed = EditorGUILayout.IntField("Speed", movementControllerScript.Speed);

        //Display list of wayPoints on the inspector
        //GUILayout.Label("WayPoints");
        EditorGUILayout.LabelField("WayPoints");
        EditorGUILayout.BeginVertical();
        // if (movementControllerScript.WayPoints != null && movementControllerScript.WayPointsCount > 0)
        // {
        //     for (int i = 0; i < movementControllerScript.WayPointsCount; i++)
        //     {
        //         movementControllerScript.WayPoints[i] = EditorGUILayout.ObjectField(movementControllerScript.WayPoints[i], typeof(GameObject), true) as GameObject;
        //     }
        // }
        if (WayPoints != null && WayPoints.Count > 0)
        {
            for (int i = 0; i < WayPoints.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                WayPoints[i] = EditorGUILayout.ObjectField(WayPoints[i], typeof(GameObject), true) as GameObject;
                GUILayout.Button("^");
                GUILayout.Button("v");
                if (GUILayout.Button("-"))
                {
                     DestroyImmediate(WayPoints[i]);
                     WayPoints.Remove(WayPoints[i]);
                }
                EditorGUILayout.EndHorizontal();
            }
        }
        EditorGUILayout.EndVertical();
        
     
        
        
        //Draw the drop zone
        Rect dropZone = GUILayoutUtility.GetRect(EditorGUIUtility.currentViewWidth, 5 * EditorGUIUtility.singleLineHeight);
        GUI.Box(dropZone, "Add wayPoint");
        
        //Clear wayPoints button
        if (GUILayout.Button("Clear"))
        {
            //movementControllerScript.ClearWayPoint();
            //wayPoints.Clear();
            WayPoints.Clear();
            //nextPoint = 0;
        }
        
        //Drag and drop event
        Event e = Event.current;
        if (e.type == EventType.DragUpdated)
        {
            //Debug.Log("Drag updated");
            DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
            e.Use();
        }

        if (e.type == EventType.DragPerform)
        {
            //Debug.Log("Drag performed");
            DragAndDrop.AcceptDrag();
            foreach (var obj in DragAndDrop.objectReferences)
            {
                GameObject gameObject = obj as GameObject;
                if (gameObject != null && !WayPoints.Contains(gameObject))
                {
                    //Debug.Log("Drag accepted");
                    //movementControllerScript.AddWayPoint(gameObject);
                    WayPoints.Add(gameObject);
                }
            }
            e.Use();
        }
    }

    //private int nextPoint = 0;
    public void OnSceneGUI()
    {
        //if (movementControllerScript.WayPoints != null && movementControllerScript.WayPointsCount > 0 )
        //{
            // Handles.color = Color.red;
            // for (int i = 0; i < movementControllerScript.WayPointsCount; i++)
            // {
            //     if (i == movementControllerScript.WayPointsCount - 1)
            //         Handles.DrawLine(movementControllerScript.WayPoints[i].transform.position,
            //             movementControllerScript.WayPoints[0].transform.position);
            //
            //     else
            //         Handles.DrawLine(movementControllerScript.WayPoints[i].transform.position,
            //             movementControllerScript.WayPoints[i + 1].transform.position);
            // }
            //
            // Handles.color = Color.red;
            // for (int i = 0; i < movementControllerScript.WayPointsCount; i++)
            // {
            //     if (i == movementControllerScript.WayPointsCount - 1)
            //         Handles.DrawLine(movementControllerScript.WayPoints[i].transform.position,
            //             movementControllerScript.WayPoints[0].transform.position);
            //
            //     else
            //         Handles.DrawLine(movementControllerScript.WayPoints[i].transform.position,
            //             movementControllerScript.WayPoints[i + 1].transform.position);
            // }
            
            // if (movementControllerScript.WayPoints != null && movementControllerScript.WayPointsCount > 0)
            // {
            //     Vector3 direction = movementControllerScript.WayPoints[nextPoint].transform.position - movementControllerScript.player.transform.position;
            //     movementControllerScript.player.transform.rotation = Quaternion.Slerp(movementControllerScript.player.transform.rotation, Quaternion.LookRotation(direction),
            //         5f);
            //
            //     if (direction.sqrMagnitude > .1f)
            //         movementControllerScript.player.transform.Translate(0, 0, movementControllerScript.speed * Time.deltaTime);
            //     else
            //         nextPoint++;
            //
            //     if (nextPoint == movementControllerScript.WayPointsCount)
            //         nextPoint = 0;
            // }
        //}
    }
}