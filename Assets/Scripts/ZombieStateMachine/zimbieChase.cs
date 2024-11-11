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

    public float chaseSpeed = 6f;
    GameObject Target_indicator;

    public float stopChasingDIstance = 15;
    public float attackingDistance = 2f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        //Target_indicator = transform.Find("DynamicTarget").gameObject;
        agent.speed = chaseSpeed;
        GameObject Target_indicator = animator.GetComponent<zombie_nav>().Target_indicator;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //agent.SetDestination(player.position);
        if (Target_indicator != null)
        {
            Target_indicator.transform.position = player.position;
        }
        animator.transform.LookAt(player);

        float distanceformPlayer = Vector3.Distance(player.position, animator.transform.position);

        if(distanceformPlayer > stopChasingDIstance)
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
        //agent.SetDestination(agent.transform.position);
        if (Target_indicator != null)
        {
            Target_indicator.transform.position = agent.transform.position;
        }
        //Target_indicator.transform.position = agent.transform.position;
    }
}
