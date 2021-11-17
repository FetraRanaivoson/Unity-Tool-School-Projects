using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DamageAttribute : PropertyAttribute
{
    public float explosionForce;

    public DamageAttribute(float explosionForce)
    {
        this.explosionForce = explosionForce;
    }

}
