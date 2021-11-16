using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BulletUISpawner : MonoBehaviour
{
    public void OnBulletEvent(GameObject gunObject)
    {
        transform.Find("NbBullets").GetComponent<Text>().text = gunObject.GetComponent<GunController>().AvailableBulletsCount.ToString();
    }
    
}
