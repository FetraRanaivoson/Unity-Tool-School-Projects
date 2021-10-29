using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player
{
    public int id;
    public int life;
    public string name;
    public Vector3 position;
    
    public Player(int id, int life, string name, Vector3 position)
    {
        this.id = id;
        this.life = life;
        this.name = name;
        this.position = position;
    }
}
