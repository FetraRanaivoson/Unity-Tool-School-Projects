using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public List<GameObject> gameObjects;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        if (gameObjects != null && gameObjects.Count != 0)
        {
            foreach (var gameObject in gameObjects)
            {
                Gizmos.DrawWireCube(gameObject.transform.position, new Vector3(2, 2, 2));
                Gizmos.DrawIcon(gameObject.transform.position + new Vector3(0, 1.5f, 0), gameObject.name);
            }

            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (i == gameObjects.Count - 1)
                    Debug.DrawLine(gameObjects[i].transform.position, gameObjects[0].transform.position, Color.red);
                else
                    Debug.DrawLine(gameObjects[i].transform.position, gameObjects[i + 1].transform.position, Color.red);
            }
        }
       
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}