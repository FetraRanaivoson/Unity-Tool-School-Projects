using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Event")]
public class Event : ScriptableObject
{
    private List<EventListener> _eventListeners = new List<EventListener>();

    public void AddEvent(EventListener listener)
    {
        _eventListeners.Add(listener);
    }

    public void RemoveEvent(EventListener listener)
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
