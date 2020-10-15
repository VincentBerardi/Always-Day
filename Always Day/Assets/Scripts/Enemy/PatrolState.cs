using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    private GhostController _target;

    public PatrolState(StateMachine stateMachine, GameObject target) : base(stateMachine)
    {
        _target = target.GetComponent<GhostController>();
    }

    public override void OnEnter()
    {
        Debug.Log("Start patroling!");
    }

    public override void Update()
    {
        if (!_target.walkPointSet) SearchWalkPoint();

        if (_target.walkPointSet)
            _target.agent.SetDestination(_target.walkPoint);

        Vector3 distanceToWalkPoint = _target.transform.position - _target.walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            _target.walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomX = Random.Range(-_target.walkPointRange, _target.walkPointRange);
        float randomZ = Random.Range(-_target.walkPointRange, _target.walkPointRange);

        _target.walkPoint = new Vector3(_target.transform.position.x + randomX, _target.transform.position.y, _target.transform.position.z + randomZ);

        NavMeshPath navMeshPath = new NavMeshPath();
        if (_target.agent.CalculatePath(_target.walkPoint, navMeshPath) && navMeshPath.status == NavMeshPathStatus.PathComplete)
            _target.walkPointSet = true;
    }

    public override void OnExit()
    {
        Debug.Log("Stop patroling!");
    }

}
