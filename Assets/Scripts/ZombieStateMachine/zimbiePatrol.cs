using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zimbiePatrol : StateMachineBehaviour
{
    float timer;
    public float patrolingTime = 10f;

    Transform player;
    NavMeshAgent agent;
    public GameObject targetIndicatorPrefab;
    private GameObject targetIndicatorInstance; 

    //[Header("Target To Walk Towards")] public Transform target; //Target the agent will walk towards during training.

    public float detectionArea = 10f;
    public float patrolSpeed = 2.0f;
    
    List<Transform> waypointList = new List<Transform>();

    GameObject Target_indicator;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        agent.speed = patrolSpeed;
        timer = 0;

        GameObject waypoint = animator.GetComponent<zombie_nav>().nvob;
        GameObject Target_indicator = animator.GetComponent<zombie_nav>().Target_indicator;

        foreach (Transform t in waypoint.transform)
        {
            waypointList.Add(t);
        }

        Vector3 nectPosition = waypointList[Random.Range(0, waypointList.Count)].position;
        //agent.SetDestination(nectPosition);
        if (Target_indicator != null){
            Target_indicator.transform.position = nectPosition;
        }
        //int a1 = 0;
        //int b1 = 1/a1;
        //if (targetIndicatorPrefab != null)
        //{
            //targetIndicatorInstance = Instantiate(targetIndicatorPrefab, nectPosition, Quaternion.identity);
            //int a = 0;
        //    int b = 1/a;
        //}
        
        //Target_indicator = animator.GetComponent<zombie_nav>().Target_indicator;
        else {
            //int a1 = 0;
            //int b1 = 1/a1;
        }
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {   
            Vector3 nectPosition_q = waypointList[Random.Range(0, waypointList.Count)].position;
            //agent.SetDestination(nectPosition_q);
            if (Target_indicator != null)
            {
                Target_indicator.transform.position = nectPosition_q;
            }
            //Target_indicator.transform.position = waypointList[Random.Range(0, waypointList.Count)].position;
        }

        // To idle
        timer += Time.deltaTime;
        if(timer > patrolingTime)
        {
            animator.SetBool("isPatroling", false);
        }

        // To Chase
        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceFromPlayer < detectionArea)
        {
            animator.SetBool("isChasing", true);
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
