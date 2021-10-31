using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerS : MonoBehaviour
{
    [ContextMenuItem("Reset Position v2", "ResetInitialPosition")]
    public Vector3 initialPosition = new Vector3(10,10,10);
    public void ResetInitialPosition()
    {
       initialPosition = new Vector3(10, 10, 10);
        
    }
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Reset Position")]
    public void ResetPosition()
    {
        transform.position = new Vector3(0, 0, 0);
        
    }
}
