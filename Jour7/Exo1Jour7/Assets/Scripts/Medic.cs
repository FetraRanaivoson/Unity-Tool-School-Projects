using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medic : MonoBehaviour
{

    public Event pickedUp;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickedUp.Occured(this.gameObject);
        }
    }

    public void ThrownUp(GameObject go)
    {
        //Debug.Log("Medic Thrown up");
        go.transform.SetParent(null);
        go.transform.Translate(0,0, 150* Time.deltaTime);
        //StartCoroutine(ActivateRigidbody(go));
    }

    IEnumerator ActivateRigidbody(GameObject go)
    {
        yield return new WaitForSeconds(.25f);
        go.gameObject.AddComponent<Rigidbody>();
    }

}
