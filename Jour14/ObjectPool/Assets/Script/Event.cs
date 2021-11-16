using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;


[CreateAssetMenu(fileName = "Create Event", menuName = "Game Event")]
public class Event : ScriptableObject
{
    private List<EventListener> _eventListeners = new List<EventListener>();

    public void Add(EventListener listener)
    {
        _eventListeners.Add(listener);
    }

    public void Remove(EventListener listener)
    {
        _eventListeners.Remove(listener);
    }

    public void Occured(GameObject gameObject)
    {
        for (int i = 0; i < _eventListeners.Count; i++)
        {
            _eventListeners[i].OnEventOccurs(gameObject);
        }
    }
}
