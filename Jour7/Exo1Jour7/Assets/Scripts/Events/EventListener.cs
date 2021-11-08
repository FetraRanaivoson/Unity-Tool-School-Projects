using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityGameObjectEvent : UnityEvent<GameObject> {}

public class EventListener : MonoBehaviour
{
    public Event gEvent;
    public UnityGameObjectEvent response = new UnityGameObjectEvent();
    private void OnEnable()
    {
        gEvent.AddEvent(this);
    }

    private void OnDisable()
    {
        gEvent.RemoveEvent(this);
    }

    public void OnEventOccurs(GameObject go)
    {
        response.Invoke(go);
    }
}
