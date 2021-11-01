using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public GameObject lastCreatedGo;
    
    private List<GameObject> prefabInstances;
    public void InstantiatePrefab(int index)
    {
        switch (index)
        {
            case 0:
                GameObject enemyType1 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/EnemyType1.prefab");
                lastCreatedGo =  GameObject.Instantiate(enemyType1 );
                break;
            case 1:
                GameObject enemyType2  = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/EnemyType2.prefab");
                lastCreatedGo =  GameObject.Instantiate(enemyType2);
                break;
            case 2:
                GameObject enemyType3 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/EnemyType3.prefab");
                lastCreatedGo =  GameObject.Instantiate(enemyType3);
                break;
                
        }
    }
    public void SwapInstancedPrefabBy(int selectedIndex)
    {
        if (lastCreatedGo != null)
        { 
            DestroyImmediate(lastCreatedGo); 
            InstantiatePrefab(selectedIndex);
        }
    }

    void Start()
    {
    }

    void Update()
    {
    }

   
}