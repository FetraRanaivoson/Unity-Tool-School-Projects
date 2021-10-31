using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntAttribute : PropertyAttribute
{
    public int NbBrique;

    public IntAttribute(int nbBrique)
    {
        NbBrique = nbBrique;
    }
}