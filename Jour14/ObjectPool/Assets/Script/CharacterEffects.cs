using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEffects : MonoBehaviour
{
    public GameObject step;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFootStep(Vector3 position)
    {
        Instantiate(step, position);
    }

    private void Instantiate(GameObject prefab, Vector3 position)
    {
        if (prefab == null)
            return;
        GameObject go = GameObject.Instantiate(prefab);
        go.transform.parent = null;
        go.transform.position = position;
        go.SetActive(true);
        GameObject.Destroy(go,1.5f);
    }
}
