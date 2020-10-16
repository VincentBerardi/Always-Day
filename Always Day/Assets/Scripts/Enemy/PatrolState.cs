using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : BaseEnemyState
{
    public PatrolState(GhostController controller) : base(controller)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("Start patroling!");
    }

    public override void Update()
    {
        if (_controller.isPlayerInSightRange())
        {
            _controller.CurrentState = new ChaseState(_controller);
            return;
        }

        if (!_controller.walkPointSet)
        {
            SearchWalkPoint();
        }

        if (_controller.walkPointSet)
        {
            _controller.agent.SetDestination(_controller.walkPoint);
        }

        Vector3 distanceToWalkPoint = _controller.transform.position - _controller.walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            _controller.walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomX = Random.Range(-_controller.walkPointRange, _controller.walkPointRange);
        float randomZ = Random.Range(-_controller.walkPointRange, _controller.walkPointRange);

        _controller.walkPoint = new Vector3(_controller.transform.position.x + randomX, _controller.transform.position.y, _controller.transform.position.z + randomZ);

        NavMeshPath navMeshPath = new NavMeshPath();
        if (_controller.agent.CalculatePath(_controller.walkPoint, navMeshPath) && navMeshPath.status == NavMeshPathStatus.PathComplete)
            _controller.walkPointSet = true;
    }

    public override void OnExit()
    {
        Debug.Log("Stop patroling!");
    }

}
