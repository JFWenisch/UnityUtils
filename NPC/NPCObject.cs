using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using CodeMonkey.Utils;
using System;

public class NPCObject : MonoBehaviour
{
    public NavMeshAgent agent;
    private bool hasEndPoint = false;

    // Start is called before the first frame update
    void Start()
    {
     
       
    
      
    }

    // Update is called once per frame
    void Update()
    {
        if(hasEndPoint)
        {

       
        if (checkReached())
        {
            Destroy(gameObject, 1.0f);
        }
        }
    }

    public void GoToTarget(Vector3 endPoint)
    {
        Debug.LogWarning("I'm need to go to "+endPoint);
        agent = this.GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("No agent found");
        }
        agent.SetDestination(endPoint);
        hasEndPoint = true;
    }

    private bool checkReached()
    {
        // Check if we've reached the destination
        if (Vector3.Distance(agent.destination, agent.transform.position) <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude < 2f)
            {

                return true;
            }
        }

        return false;
    }
}
