using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomAudio : MonoBehaviour
{
    public AudioClip[] audioClips;

    private void Awake()
    {
        Play();
    }

    private void Play()
    {
        if (audioClips.Length == 0)
            return;
        AudioSource source = GetComponent<AudioSource>();
        if (source == null) 
            return;
        source.clip = audioClips[Random.Range(0, audioClips.Length)];
    }
}
