using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ObserverPattern
{
    public interface Observer
    {
        void OnNotify(string eventName);
    }

    public class Subject
    {
        List<Observer> observers = new List<Observer>();

        public void Notify(string eventName)
        {
            for (int i = 0; i < observers.Count; i++)
            {
                observers[i].OnNotify(eventName);
            }
        }

        public void AddObserver(Observer observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(Observer observer)
        {
            observers.Remove(observer);
        }
    }
}
