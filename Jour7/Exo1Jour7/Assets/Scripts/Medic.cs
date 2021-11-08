using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medic : MonoBehaviour
{

    public Event pickedUp;
    
    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         pickedUp.Occured(this.gameObject);
    //     }
    // }
    //
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickedUp.Occured(this.gameObject);
        }
    }
}
