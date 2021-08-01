using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AutoMoveAgent : MonoBehaviour
{

    public GameObject targetObject;

    private Vector3 starting;
    public Vector3 ending;
    private bool reachedTarget = false;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {

        agent = this.GetComponent<NavMeshAgent>();
        if(agent==null)
        {
            Debug.LogError("No agent found");
        }
        else
        {
            starting = this.transform.position;
            SetDestination();
       
        }
    }

    private void SetDestination()
    {
        if(!reachedTarget)
        {
            agent.SetDestination(targetObject.transform.position);
        }
        else
        {
            agent.SetDestination(starting);
        }
    }

    private bool checkReached()
    {
        // Check if we've reached the destination
        if (Vector3.Distance(agent.destination, agent.transform.position) <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude  <2f)
            {
              
                return true;
            }
        }

        return false;
    }
    // Update is called once per frame
    void Update()
    {

     
        if (checkReached() )
        {
            if (!reachedTarget)
            {
                reachedTarget = true;
                GlobalManager.points++;


                agent.isStopped = true;
                agent.SetDestination(starting);
                agent.isStopped = false;
               


            }
        }
        //SetDestination();
    }
}
