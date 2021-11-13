using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEffects : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip shot;
    [SerializeField]
    private AudioClip emptyBullet;

    public void OnShot()
    {
        audioSource.PlayOneShot(shot);
    }
    
    public void OnEmptyBullet()
    {
        audioSource.PlayOneShot(emptyBullet);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
