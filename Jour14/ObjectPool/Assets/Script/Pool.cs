using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolBullet
{
    public GameObject bulletPrefab;
    public int count;
}

public class Pool : MonoBehaviour
{
    public static Pool PoolInstance;
    public List<PoolBullet> inactiveBullets;
    public List<GameObject> activeBullets;

    private void Awake()
    {
        PoolInstance = this;
        
        activeBullets = new List<GameObject>();
        foreach (PoolBullet inactiveBullet in inactiveBullets)
        {
            for (int i = 0; i < inactiveBullet.count; i++)
            {
                GameObject toPull = Instantiate(inactiveBullet.bulletPrefab);
                toPull.SetActive(false);
                activeBullets.Add(toPull);
            }
        }
    }

    public int GetAvailableBullets()
    {
        int count = 0;
        foreach (GameObject activeBullet in activeBullets)
        {
            if (!activeBullet.activeSelf)
            {
                count++;
            }
        }

        return count;
    }
    
    void Start()
    {
    
    }

    public GameObject GetActiveBullets(string tag)
    {
        for (int i = 0; i < activeBullets.Count; i++)
        {
            if (!activeBullets[i].activeInHierarchy && activeBullets[i].CompareTag(tag))
            {
                return activeBullets[i];
            }
        }
        return null;
    }


   


    void Update()
    {
        
    }
}
