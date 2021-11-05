using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public string name;
    public Vector3 position;
    public Vector3 velocity;
    public Color color;
    public PlayerData()
    {
    }

    public PlayerData(string name,Vector3 position, Vector3 velocity, Color color)
    {
        this.name = name;
        this.position = position;
        this.velocity = velocity;
        this.color = color;
    }
}
