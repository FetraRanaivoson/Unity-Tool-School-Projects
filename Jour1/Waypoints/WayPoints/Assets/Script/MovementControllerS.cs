using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControllerS : MonoBehaviour
{
    [HideInInspector] public int speed = 2;
    public GameObject player;

    private List<GameObject> wayPoints;
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

    //public List<GameObject> gameObjects;

    // public void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.yellow;
    //     if (gameObjects != null && gameObjects.Count != 0)
    //     {
    //         foreach (var gameObject in gameObjects)
    //         {
    //             Gizmos.DrawWireCube(gameObject.transform.position, new Vector3(1, 1, 1));
    //             Gizmos.DrawIcon(gameObject.transform.position + new Vector3(0, 1.5f, 0), gameObject.name);
    //         }
    //
    //         for (int i = 0; i < gameObjects.Count; i++)
    //         {
    //             if (i == gameObjects.Count - 1)
    //                 Debug.DrawLine(gameObjects[i].transform.position, gameObjects[0].transform.position, Color.red);
    //             else
    //                 Debug.DrawLine(gameObjects[i].transform.position, gameObjects[i + 1].transform.position, Color.red);
    //         }
    //     }
    // }

    // Start is called before the first frame update
    void Start()
    {
    }

    private int nextPoint = 0;

    // Update is called once per frame
    void Update()
    {
        
    }
}