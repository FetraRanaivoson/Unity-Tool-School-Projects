using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    private static List<GameObject> e = new List<GameObject>();
    
    [EnemyLists(e)]
    public List<GameObject> enemiesType;
    void Start()
    {
    }
    
    void Update()
    {
    }
}
