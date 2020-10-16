using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostController : StateMachine
{
    public enum GhostType { Red, Green, Blue };

    public NavMeshAgent agent;
    public Rigidbody rigidBody;
    public Transform player;

    [Header("References")]
    [SerializeField]
    public LayerMask whatIsGround;
    [SerializeField]
    public LayerMask whatIsPlayer;

    [Header("Patroling")]
    [SerializeField]
    public Vector3 walkPoint;
    [SerializeField]
    public bool walkPointSet;
    [SerializeField]
    public float walkPointRange = 50f;

    [Header("Attacking")]
    [SerializeField]
    public float timeBetweenAttacks = 1f;
    [SerializeField]
    public float projectileForce = 32f;
    [SerializeField]
    public float rammingForce = 1f;
    [SerializeField]
    public bool alreadyAttacked;
    [SerializeField]
    public GameObject projectile;
    [SerializeField]
    public float projectileStartDist = 2f;

    [Header("States")]
    [SerializeField]
    public float sightRange = 24f;
    [SerializeField]
    public float attackRange = 15f;
    [SerializeField]
    public bool playerInSightRange;
    [SerializeField]
    public bool playerInAttackRange;
    [SerializeField]
    public GhostType ghostType = GhostType.Red;

    private void Awake()
    {

        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.isKinematic = false;

        this.CurrentState = new PatrolState(this);
    }

    private void Update()
    {
        this.CurrentState.Update();
    }

    public bool isPlayerInSightRange()
    {
        return Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
    }

    public bool isPlayerInAttackRange()
    {
        return Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerController>().GetStunned();
            agent.enabled = true;
            rigidBody.isKinematic = true;
        }
        if (collision.transform.CompareTag("Wall"))
        {
            agent.enabled = true;
            rigidBody.isKinematic = true;
        }

    }

    public void ResetAttack()
    {
        alreadyAttacked = false;
        agent.enabled = true;
        rigidBody.isKinematic = true;
    }


}
