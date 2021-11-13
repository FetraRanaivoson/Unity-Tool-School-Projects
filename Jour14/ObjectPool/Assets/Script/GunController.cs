using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GunController : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletOrigin;
    public GunEffects gunEffects;

    private Color initialColor;

    private void Awake()
    {
        initialColor = this.gameObject.GetComponentInChildren<MeshRenderer>().material.color;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Clicked");
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                Vector3 direction = hit.point - this.transform.position;
                Debug.DrawRay(this.transform.position, direction);
                this.transform.LookAt(direction, Vector3.up);
            }
        }

        GameObject pooledBullet = Pool.PoolInstance.GetActiveBullets("Bullet");
        if (pooledBullet != null)
        {
            this.gameObject.GetComponentInChildren<MeshRenderer>().material.color = initialColor;
        }

        if (Input.GetMouseButtonDown(1))
        {
            //Instantiate(bullet, bulletOrigin.position, bulletOrigin.transform.rotation);
            pooledBullet = Pool.PoolInstance.GetActiveBullets("Bullet");
            if (pooledBullet != null)
            {
                gunEffects.OnShot();
                this.gameObject.GetComponentInChildren<MeshRenderer>().material.color = initialColor;
                //pooledBullet.transform.SetParent(bulletOrigin);
                pooledBullet.transform.position = bulletOrigin.position;
                pooledBullet.transform.rotation = bulletOrigin.transform.rotation;
                //pooledBullet.transform.localPosition = Vector3.zero;
                pooledBullet.SetActive(true);
            }
            else
            {
                gunEffects.OnEmptyBullet();
                this.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            }

        }
        
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(- 2 * Time.deltaTime,0, 0);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(2 * Time.deltaTime,0, 0);
        }
    }
}
