using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public string name;
    public Vector3 Position;
    
    public PlayerData()
    {
    }

    public PlayerData(string name,Vector3 position)
    {
        this.name = name;
        this.Position = position;
    }
}
