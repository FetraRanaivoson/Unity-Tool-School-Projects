using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListsAttribute : PropertyAttribute
{
    public List<GameObject> enemiesResources = new List<GameObject>();
    Enum enemy   {EnemyType1, EnemyType2, EnemyType3};
    public EnemyListsAttribute(List<GameObject> enemiesResources)
    {
        // GameObject resource1 = Resources.Load<GameObject>("Prefabs/EnemyType1");
        // GameObject resource2 = Resources.Load<GameObject>("Prefabs/EnemyType2");
        // GameObject resource3 = Resources.Load<GameObject>("Prefabs/EnemyType3");
        // enemiesResources.Add(resource1);
        // enemiesResources.Add(resource2);
        // enemiesResources.Add(resource3);
        this.enemiesResources = enemiesResources;
    }

    public void InstantiateEnemy(GameObject enemy)
    {
        GameObject enemyType = GameObject.Instantiate(enemy);
    }
}