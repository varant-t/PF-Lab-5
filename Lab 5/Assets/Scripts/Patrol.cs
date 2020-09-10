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

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;

    Subject subject = new Subject();

    void Start()
    {
        if (chaseRange <= 0)
        {
            chaseRange = 8f;
        }

        WaitTime = startWaittime;
        randomWp = Random.Range(0, waypoint.Length);

        Enemy chase1 = new Enemy(enemy1);
        Enemy chase2 = new Enemy(enemy2);
        Enemy chase3 = new Enemy(enemy3);
        Enemy chase4 = new Enemy(enemy4);
        Enemy chase5 = new Enemy(enemy5);

        subject.AddObserver(chase1);
        subject.AddObserver(chase2);
        subject.AddObserver(chase3);
        subject.AddObserver(chase4);
        subject.AddObserver(chase5);
    }

    
    void Update()
    {
        if (Vector3.Distance(player.position, gameObject.transform.position) < chaseRange)
        {
            Chase();
            subject.Notify();
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



    public void Chase()
    {
        isPatrolling = false;
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
