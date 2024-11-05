using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class zimbieChase : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;

    // dayand night
    DayNightCycle dayNightCycle;

    public float chaseSpeed = 6f;

    //public float stopChasingDIstance = 15;
    public float attackingDistance = 2f;

    //
    public float dayStopChasingDistance = 15f;
    public float nightStopChasingDistance = 25f;
    private float stopChasingDIstance;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

      if (agent == null || !agent.isOnNavMesh || !agent.enabled)
        {
            Debug.LogWarning("NavMeshAgent is not enabled or not on a NavMesh. Skipping chase setup.");
            return;
        }
        dayNightCycle = FindObjectOfType<DayNightCycle>();

        agent.speed = chaseSpeed;
        
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if (agent == null || !agent.isOnNavMesh || !agent.enabled) return;
        
       

        agent.SetDestination(player.position);
        animator.transform.LookAt(player);

        float distanceformPlayer = Vector3.Distance(player.position, animator.transform.position);

        //
      
        if (dayNightCycle != null && dayNightCycle.IsNight())
        {
            stopChasingDIstance = nightStopChasingDistance;
        }
        else
        {
            stopChasingDIstance = dayStopChasingDistance;
        }


        if (distanceformPlayer > stopChasingDIstance)
        {
            animator.SetBool("isChasing", false);
        }

        if(distanceformPlayer < attackingDistance)
        {
            animator.SetBool("isAttacking", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
