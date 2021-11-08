using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public GameObject actor;
    private Player _player;
    
    void Start()
    {
        _player = actor.GetComponent<Player>();
    }
    
    void Update()
    {
        _player.HandleInput();
        _player.InvokeFollower();
    }
}
