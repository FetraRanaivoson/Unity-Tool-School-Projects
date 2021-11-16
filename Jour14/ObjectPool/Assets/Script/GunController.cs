using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class GunController : MonoBehaviour
{
    public Transform bulletOrigin;
    private GunEffects _gunEffects;
    private CharacterEffects _characterEffects;

    public Event bulletEvent;

    private Transform _firstPersonView;
    private Vector3 _firstPersonViewRotation;

    private float _inputX, _inputY;
    private float _inputXSet, _inputYSet;
    private Vector3 _moveDirection;
    private CharacterController _characterController;

    private Color _initialGunColor;

    public int AvailableBulletsCount => Pool.PoolInstance.GetAvailableBullets();

    private void Awake()
    {
        _initialGunColor = gameObject.GetComponentInChildren<MeshRenderer>().material.color;
        _firstPersonView = transform.Find("FPSView").transform;

        _gunEffects = GetComponent<GunEffects>();
        _characterEffects = GetComponent<CharacterEffects>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        bulletEvent.Occured(this.gameObject);
    }

    private float currentTime = 0;
    private float lastTimeUpdate = 0;
    
    void LateUpdate()
    {
        currentTime = Time.time;
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.W))
                _inputYSet = 1;
            else
                _inputYSet = -1;

            
            if (currentTime - lastTimeUpdate > .05f)
            {
                _characterEffects.OnFootStep(this.transform.position);
                lastTimeUpdate = currentTime;
            }
               
        }
        else
            _inputYSet = 0;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
                _inputXSet = -1;
            else
                _inputXSet = 1;
            
            if (currentTime - lastTimeUpdate > .25f)
            {
                _characterEffects.OnFootStep(this.transform.position);
                lastTimeUpdate = currentTime;
            }
        }
        else
            _inputXSet = 0;

        _inputY = Mathf.Lerp(_inputY, _inputYSet, Time.deltaTime * 10);
        _inputX = Mathf.Lerp(_inputX, _inputXSet, Time.deltaTime * 10);


        _firstPersonViewRotation = Vector3.Lerp(_firstPersonViewRotation,
            Vector3.zero, Time.deltaTime * 5);
        _firstPersonView.localEulerAngles = _firstPersonViewRotation; //local = relative to its parent

        //If grounded
        _moveDirection = new Vector3(_inputX * .1f, 0, _inputY * .1f); //factor
        _moveDirection = transform.TransformDirection(_moveDirection) * .45f; //speed


        _characterController.Move(_moveDirection);

        // if (Input.GetMouseButton(0))
        // {
        //     Debug.Log("Clicked");
        //     RaycastHit hit;
        //     if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        //     {
        //         Vector3 direction = hit.point - this.transform.position;
        //         Debug.DrawRay(this.transform.position, direction);
        //         this.transform.LookAt(direction, Vector3.up);
        //     }
        // }
        //

        GameObject pooledBullet = Pool.PoolInstance.GetActiveBullets("Bullet");
        if (pooledBullet != null)
        {
            this.gameObject.GetComponentInChildren<MeshRenderer>().material.color = _initialGunColor;
        }

        if (Input.GetMouseButtonDown(1))
        {
            //Instantiate(bullet, bulletOrigin.position, bulletOrigin.transform.rotation);
            pooledBullet = Pool.PoolInstance.GetActiveBullets("Bullet");
            if (pooledBullet != null)
            {
                _gunEffects.OnShot();
                this.gameObject.GetComponentInChildren<MeshRenderer>().material.color = _initialGunColor;
                //pooledBullet.transform.SetParent(bulletOrigin);
                pooledBullet.transform.position = bulletOrigin.position;
                pooledBullet.transform.rotation = bulletOrigin.transform.rotation;
                //pooledBullet.transform.localPosition = Vector3.zero;
                pooledBullet.SetActive(true);
            }
            else
            {
                _gunEffects.OnEmptyBullet();
                this.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            }
        }

        bulletEvent.Occured(this.gameObject);
    }
}