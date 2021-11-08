using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    private void OnEnable()
    {
        Player.follow += ExecuteFollow ; //this.function subscribe to the follow event of the player
    }

    private void OnDisable()
    {
        Player.follow -= ExecuteFollow ;
    }


    private float _velocity;
    private float _lookAtVelocity;
    private void Awake()
    {
        _velocity = 5;
        _lookAtVelocity = 5;
    }

    void ExecuteFollow(GameObject player) //Will be executed after "follow" event is called
    {
        //Debug.Log("Follower is now following " + player.name);
        Vector3 direction = player.transform.position - this.transform.position;
        this.transform.rotation = Quaternion.Slerp( this.transform.rotation,
            Quaternion.LookRotation(direction), _lookAtVelocity * Time.deltaTime);
        this.transform.Translate(0,0, _velocity* Time.deltaTime);
    }
    
    void Start()
    {
    }
    
    void Update()
    {
    }
}
