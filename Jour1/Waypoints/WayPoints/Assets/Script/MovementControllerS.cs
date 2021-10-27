using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControllerS : MonoBehaviour
{
    [HideInInspector] public int Speed { get; set; } = 2;

    [HideInInspector] public List<GameObject> wayPoints;
    public List<GameObject> WayPoints => wayPoints;
    public int WayPointsCount => wayPoints.Count;
    public void AddWayPoint(GameObject wayPoint)
    {
        wayPoints.Add(wayPoint);
    }
    public void ClearWayPoint()
    {
        wayPoints.Clear();
    }
    
    
    void Start()
    {
    }


    void Update()
    {
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (WayPoints != null && WayPoints.Count != 0)
        {
            for (int i = 0; i < WayPointsCount; i++)
            {
                if (i == WayPointsCount - 1)
                    Gizmos.DrawLine(WayPoints[i].transform.position,
                        WayPoints[0].transform.position);

                else
                    Gizmos.DrawLine(WayPoints[i].transform.position,
                        WayPoints[i + 1].transform.position);
            }
        }
    }
}