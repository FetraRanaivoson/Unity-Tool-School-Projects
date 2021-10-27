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
        
        //Display movement parameter
        EditorGUILayout.LabelField("Movement Controller Params");
        movementControllerScript.GetComponent<Player>().speed = EditorGUILayout.IntField("Speed", movementControllerScript.GetComponent<Player>().speed); //GUILayout.Label("Movement Controller Params");
        //movementControllerScript.GetComponent<Player>().speed = playerSpeed;         
       
        WayPointsGUI();
        DropZoneGUI();

        //Clear wayPoints button
        if (GUILayout.Button("Clear"))
            WayPoints.Clear();

        ManageDragEvents();
    }

    private void ManageDragEvents()
    {
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
    private static void DropZoneGUI()
    {
        //Draw the drop zone
        Rect dropZone = GUILayoutUtility.GetRect(EditorGUIUtility.currentViewWidth, 2 * EditorGUIUtility.singleLineHeight);
        GUI.Box(dropZone, "Add wayPoint");
    }
    private void WayPointsGUI()
    {
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
                if (GUILayout.Button("^"))
                {
                    if (i > 0)
                    {
                        GameObject wayPointUpper = WayPoints[i - 1];
                        WayPoints[i - 1] = WayPoints[i];
                        WayPoints[i] = wayPointUpper;
                    }
                }

                if (GUILayout.Button("v"))
                {
                    if (i < WayPoints.Count - 1)
                    {
                        GameObject wayPointLower = WayPoints[i + 1];
                        WayPoints[i + 1] = WayPoints[i];
                        WayPoints[i] = wayPointLower;
                    }
                }

                if (GUILayout.Button("-"))
                {
                    DestroyImmediate(WayPoints[i]);
                    WayPoints.Remove(WayPoints[i]);
                }

                EditorGUILayout.EndHorizontal();
            }
        }

        EditorGUILayout.EndVertical();
    }
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