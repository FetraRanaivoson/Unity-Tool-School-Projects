using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEffects : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip shot;
    [SerializeField]
    private AudioClip emptyBullet;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnShot()
    {
        //audioSource.PlayOneShot(shot);
        _audioSource.clip = shot;
        _audioSource.Play();
    }
    
    public void OnEmptyBullet()
    {
        //audioSource.PlayOneShot(emptyBullet);
        _audioSource.clip = emptyBullet;
        _audioSource.Play();
    }

}
