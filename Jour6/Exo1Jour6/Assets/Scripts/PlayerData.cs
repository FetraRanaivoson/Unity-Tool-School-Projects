using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public string name;
    public Vector3 position;
    public float velocity;
    
    public PlayerData()
    {
    }

    public PlayerData(string name,Vector3 position, float velocity)
    {
        this.name = name;
        this.position = position;
        this.velocity = velocity;
    }
}
