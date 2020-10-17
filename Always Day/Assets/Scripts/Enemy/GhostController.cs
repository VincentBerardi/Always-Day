using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostController : StateMachine
{
    public enum GhostType { Red, Green, Blue };
    public GhostType ghostType;

    public NavMeshAgent agent;
    public Rigidbody rigidBody;
    public Transform player;

    [Header("References")]
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;

    [Header("Patroling")]
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange = 50f;

    [Header("Attacking")]
    public float timeBetweenAttacks = 1f;
    public float projectileStartDist = 2f;
    public float projectileForce = 32f;
    public float rammingForce = 1f;
    public bool alreadyAttacked;
    public GameObject projectile;


    [Header("Green Ghost Attack")]
    public GameObject greenProjectileAttack;

    [Header("Blue Ghost Attack")]
    public GameObject blueProjectileAttack;
    public GameObject blueSpecialAttack;


    [Header("States")]
    public float sightRange = 24f;
    public float attackRange = 15f;
    public bool playerInSightRange;
    public bool playerInAttackRange;


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
