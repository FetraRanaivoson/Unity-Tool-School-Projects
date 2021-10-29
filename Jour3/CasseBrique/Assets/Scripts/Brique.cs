using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Brique : MonoBehaviour
{
    public int nbBrick;

    public Brique(int nbBrick)
    {
        this.nbBrick = nbBrick;
    }
}
