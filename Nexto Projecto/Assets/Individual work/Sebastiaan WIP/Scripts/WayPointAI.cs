using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class WayPointAI : MonoBehaviour {
    private NavMeshAgent agent;

    public List<Transform> waypoints = new List<Transform>();

    [Header("TypeofAI")]
    public bool randomWaypoint;
    public bool followList;


    [Header("IdleTimer")]
    public float idleTimerMin;
    public float idleTimerMax;

    private float idleTimer;
    private int currCheckPoint;


    private void Awake()
    {
        agent = transform.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        IdleTimer();   
    }

    void RandomAI()
    {
        agent.destination = waypoints[Random.Range(0, waypoints.Count)].position;
    }

    void FollowAI()
    {

        if (currCheckPoint < waypoints.Count-1)
            currCheckPoint++;
        else
            currCheckPoint = 0;

        agent.destination = waypoints[currCheckPoint].position;
    }

    void IdleTimer()
    {
        idleTimer -= Time.deltaTime;
        if (idleTimer <= 0)
        {
            if (randomWaypoint &&agent.remainingDistance ==0f)
                RandomAI();

            if (followList&&agent.remainingDistance ==0f)
                FollowAI();

            idleTimer = Random.Range(idleTimerMin, idleTimerMax);
        }
    }
}
