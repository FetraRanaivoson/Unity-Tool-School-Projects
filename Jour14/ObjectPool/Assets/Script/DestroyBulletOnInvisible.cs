using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletOnInvisible : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);
    }
    
}
