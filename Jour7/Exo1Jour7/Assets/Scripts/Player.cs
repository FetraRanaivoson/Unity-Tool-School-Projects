using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void
        Follow(GameObject gameObject); //The letter you need to deliver to smb but you don't care who the person is

    //The letter: this event is pointing to the variable(function) that is subscribed to it
    //We don't care who will send the letter, we only care any subscriber gets the letter
    public static event Follow follow;

    private Command _moveForward;
    private Command _rotate;
    private float _moveVelocity;
    private float _rotateVelocity;

    public Event thrownUp;

    void Start()
    {
        //follow?.Invoke(this.gameObject);//must have the same signature as the delegate
        _moveForward = new PerformMove();
        _rotate = new PerformRotate();
        _moveVelocity = 10;
        _rotateVelocity = 150;
    }

    private MyStack<GameObject> _medicStack = new MyStack<GameObject>();
    public List<Transform> slots = new List<Transform>(4);

    public void PickedUpItem(GameObject go)
    {
        //Debug.Log("Medic picked up");
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (slots[i].childCount == 0)
            {
                go.transform.SetParent(slots[i]);
                go.transform.localPosition = new Vector3(0, 4, 0);
                _medicStack.Add(go);
                break;
            }
        }
    }

    
    public void ThrowUpItem()
    {
        bool somethingToThrow = false;
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].childCount > 0)
            {
                somethingToThrow = true;
                break;
            }
        }
        if (somethingToThrow)
        {
            thrownUp.Occured(_medicStack.Last);
            _medicStack.PopLast();
            Debug.Log(_medicStack.ElementCount);
        }
      
    }

    public void HandleInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            _moveForward.Execute(this.transform, this._moveVelocity, Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            _moveForward.Execute(this.transform, -this._moveVelocity, Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            _rotate.Execute(this.transform, -this._rotateVelocity, Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            _rotate.Execute(this.transform, this._rotateVelocity, Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.T))
            ThrowUpItem();
    }

    public void InvokeFollower()
    {
        follow?.Invoke(this.gameObject); //must have the same signature as the delegate
        //follow(this.gameObject);
    }

    private void Update()
    {
        Debug.Log(_medicStack.ElementCount);
    }
}