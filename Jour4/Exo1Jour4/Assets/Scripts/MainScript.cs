using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    private void Awake()
    {
        // GameObject clone = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/");
        // GameObject.Instantiate(clone);
        //
        // string[] files = Directory.GetFiles("./");

        //GameObject resource1 = Resources.Load<GameObject>("Prefabs/EnemyType1");
        //GameObject resource2 = Resources.Load<GameObject>("Prefabs/EnemyType2");
        //GameObject resource3 = Resources.Load<GameObject>("Prefabs/EnemyType3");
    }

    public void InstantiatePrefab(int index)
    {
        switch (index)
        {
            case 0:
                GameObject enemyType1 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/EnemyType1.prefab");
                GameObject.Instantiate(enemyType1 );
                break;
            case 1:
                GameObject enemyType2  = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/EnemyType2.prefab");
                GameObject.Instantiate(enemyType2);
                break;
            case 2:
                GameObject enemyType3 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/EnemyType3.prefab");
                GameObject.Instantiate(enemyType3);
                break;
                
        }
    }


    void Start()
    {
    }

    void Update()
    {
    }
}