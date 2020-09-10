using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Observer
{
   
    public abstract void OnNotify();
}

public class Enemy : Observer
{

    //The box gameobject which will do something
    GameObject enemy;
   


    public Enemy(GameObject enemy) //BoxEvents boxEvent)
    {
        this.enemy = enemy;
        //this.boxEvent = boxEvent;
    }

    //What the box will do if the event fits it (will always fit but you will probably change that on your own)
    public override void OnNotify()
    {
       
    }
}

