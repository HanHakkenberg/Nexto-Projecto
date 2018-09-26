﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AIManager : MonoBehaviour
{

    [Header("")]
    public NavMeshPath path;
    public float tick = 1f;
    public Vector3 destination;
    public Vector2 walkSize;

    public List<NavMeshAgent> agents = new List<NavMeshAgent>();

    void Update()
    {
        TickRate();
    }

    private void AssignPath(NavMeshAgent agent)
    {

        destination = new Vector3(Random.Range(-walkSize.x, walkSize.x), 0, Random.Range(-walkSize.y, walkSize.y));
        if (CalculatePath(agent) == true)
        {
            print("path available");
            agent.destination = destination;
        }
        else
        {
            AssignPath(agent);
            print("path not available,setting new destination");
        }

    }


    bool CalculatePath(NavMeshAgent agent)
    {
        path = new NavMeshPath();

        agent.CalculatePath(destination, path);

        if (path.status != NavMeshPathStatus.PathComplete)
            return false;
        else
            return true;


    }

    void TickRate()
    {
        tick -= Time.deltaTime;
        if (tick <= 0)
        {
            for (int i = 0; i < agents.Count; i++)
            {
                if (agents[i].remainingDistance ==0f)
                {
                    AssignPath(agents[i]);
                }
                tick = Random.Range(3f, 8f);
            }
        }
    }
}
