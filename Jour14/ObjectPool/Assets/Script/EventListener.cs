using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GameObjectEvent: UnityEvent<GameObject>{}
public class EventListener : MonoBehaviour
{
   public Event gameEvent;
   public GameObjectEvent response = new GameObjectEvent();

   private void OnEnable()
   {
      gameEvent.Add(this);
   }

   private void OnDisable()
   {
      gameEvent.Remove(this);
   }

   public void OnEventOccurs(GameObject gameObject)
   {
      response.Invoke(gameObject);
   }
}
