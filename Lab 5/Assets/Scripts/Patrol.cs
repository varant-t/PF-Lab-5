using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform player;
    public GameObject[] waypoint;
    private int randomWp;
    public float speed;
    public float startWaittime;
    public float WaitTime;



    public float chaseRange;


    bool isPatrolling = false;

    void Start()
    {
        if (chaseRange <= 0)
        {
            chaseRange = 8f;
        }

        WaitTime = startWaittime;
        randomWp = Random.Range(0, waypoint.Length);
    }

    
    void Update()
    {
        if (Vector3.Distance(player.position, gameObject.transform.position) < chaseRange)
        {
            Chase();
        }
        else if (!isPatrolling)

        transform.position = Vector3.MoveTowards(transform.position, waypoint[randomWp].transform.position, speed * Time.deltaTime);


        if(Vector3.Distance(transform.position, waypoint[randomWp].transform.position) < 0.2f )
        {
            if(WaitTime <= 0)
            {
                randomWp = Random.Range(0, waypoint.Length);
                WaitTime = startWaittime;
            }
            else
            {
                WaitTime -= Time.deltaTime;
            }
        }
    }



    private void Chase()
    {
        isPatrolling = false;
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
  
    }


}
