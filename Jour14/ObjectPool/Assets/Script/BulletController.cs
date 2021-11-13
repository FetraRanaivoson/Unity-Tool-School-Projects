using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float speed = 15;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Target") || other.gameObject.CompareTag("Ground"))
        {
            this.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        transform.Translate(0,0, speed * Time.deltaTime);
    }
}
