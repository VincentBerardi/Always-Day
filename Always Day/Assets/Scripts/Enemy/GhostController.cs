using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostController : StateMachine
{
    public enum GhostType { Red, Green, Blue};

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

        this.CurrentState = new PatrolState(this, this.gameObject);
    }

    private void Update()
    {
        this.CurrentState.Update();

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (CurrentState.GetType() != typeof(PatrolState) && !playerInSightRange && !playerInAttackRange)
            this.CurrentState = new PatrolState(this, this.gameObject);
        if (CurrentState.GetType() != typeof(ChaseState) && playerInSightRange && !playerInAttackRange)
            this.CurrentState = new ChaseState(this, this.gameObject);
        if (CurrentState.GetType() != typeof(AttackState) && playerInSightRange && playerInAttackRange)
            this.CurrentState = new AttackState(this, this.gameObject);
    }

    public void ShootProjectile()
    {
        switch (ghostType)
        {
            case GhostType.Red:
                Rigidbody rb = Instantiate(projectile, transform.position + transform.forward * projectileStartDist, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * projectileForce, ForceMode.Impulse);
                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
                break;
            case GhostType.Green:
                //TODO
                break;
            case GhostType.Blue:
                //TODO
                break;
        }
    }

    public void SpecialAttack()
    {
        switch (ghostType) {
            case GhostType.Red:
                rigidBody.isKinematic = false;
                agent.enabled = false;
                rigidBody.AddForce(transform.forward * rammingForce, ForceMode.Impulse);
                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
                break;
            case GhostType.Green:
                //TODO
                break;
            case GhostType.Blue:
                //TODO
                break;
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        agent.enabled = true;
        rigidBody.isKinematic = true;
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
}
