using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[ExecuteInEditMode]

public class GizmoCube : MonoBehaviour
{
    [SerializeField]
    private int life = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawLine(new Vector3(0,0,0), new Vector3(0,5,0), Color.red);
       // Debug.DrawRay(new Vector3(0,0,0), transform.forward * 10, Color.red);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 5);
        Gizmos.DrawWireCube(transform.position, new Vector3(2,2,2));
    }
    
}
