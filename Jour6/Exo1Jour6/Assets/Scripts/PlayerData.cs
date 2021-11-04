using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public Vector3 Position;

    public PlayerData()
    {
    }

    public PlayerData(Vector3 position)
    {
        this.Position = position;
    }
}
