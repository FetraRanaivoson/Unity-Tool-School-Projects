using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerS : MonoBehaviour
{
    //[ContextMenuItem("Reset", "ResetPosition")]
    //private Transform transform;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("ResetPosition")]
    public void ResetPosition()
    {
        transform.position = new Vector3(0, 0, 0);
    }
}
