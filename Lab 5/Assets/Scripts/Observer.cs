using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public abstract class Observer : MonoBehaviour
    {
        public abstract void OnNotify();
    }

    public class Box : Observer
    {
        //The box gameobject which will do something
        GameObject boxObj;
        
    
        //What the box will do if the event fits it (will always fit but you will probably change that on your own)
        public override void OnNotify()
        {
            
        }

    }
