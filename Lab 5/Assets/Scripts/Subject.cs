using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    List<Observer> observers = new List<Observer>();
    public void OnNotify()
    {
        for(int i= 0; i < observers.Count; i++)
        {
            observers[i].OnNotify();
        }
    }

    //Add observer to the list
    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    //Remove observer from the list
    public void RemoveObserver(Observer observer)
    {

    }


}
