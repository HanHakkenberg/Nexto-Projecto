using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AIManager : MonoBehaviour
{

    [Header("WalkArea")]
    public Vector2 walkSizeX;
    public Vector2 walkSizeY;

    private NavMeshPath path;

    private float tick = 1f;

    private Vector3 destination;


    public List<NavMeshAgent> agents = new List<NavMeshAgent>();

    void Update()
    {
        TickRate();

        if (Input.GetButtonDown("Fire3"))
        {
            CheckIfStuck();
        }
    }

    void TickRate()
    {
        tick -= Time.deltaTime;
        if (tick <= 0)
        {
            GivePath();
            CheckIfStuck();

            tick = 1f;
        }
    }

    private void SetPath(NavMeshAgent agent)
    {

        destination = new Vector3(Random.Range(walkSizeX.x, walkSizeX.y), 0, Random.Range(walkSizeY.x, walkSizeY.y));
        if (CalculatePath(agent))
            agent.destination = destination;
        else
            SetPath(agent);
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

    void GivePath()
    {
        for (int i = 0; i < agents.Count; i++)
            if (agents[i].remainingDistance == 0f)
                SetPath(agents[i]);
    }

    void CheckIfStuck()
    {
        for (int i = 0; i < agents.Count; i++)
            if (agents[i].velocity.x <= 0.1f && agents[i].velocity.z <= 0.1f )
                if (agents[i].velocity.x >= -0.1f && agents[i].velocity.z >= -0.1f)
                    if(agents[i].remainingDistance >= 0.2f)               
                    SetPath(agents[i]);                
    }
}
