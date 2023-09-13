using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform[] targetsTR;
    [SerializeField] Transform currentTargetTR;
    [SerializeField] Animator anim;
    [SerializeField] float velocity;
    [SerializeField] float arrivalDistance;
    [SerializeField] float distanceToPlayer;
    [SerializeField] Transform player;
    [SerializeField] bool chaseMode;

    int currentTarget = 0;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        //player = FindObjectOfType<CharacterController>().GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        agent.destination = targetsTR[currentTarget].position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position,player.position);

        if (chaseMode)
        {
            currentTargetTR = player;

        }else if (agent.remainingDistance <= arrivalDistance)
        {
            if (currentTarget < targetsTR.Length - 1)
            {
                currentTarget++;
            }
            else
            {
                currentTarget = 0;
            }

            agent.destination = targetsTR[currentTarget].position;
        }        

        velocity = agent.velocity.magnitude;
        anim.SetFloat("Speed",velocity);
    }
}
