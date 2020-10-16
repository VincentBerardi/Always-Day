using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseEnemyState
{
    public ChaseState(GhostController controller) : base(controller)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("Start chasing!");
    }
    public override void Update()
    {

        if (!_controller.isPlayerInSightRange())
        {
            _controller.CurrentState = new PatrolState(_controller);
            return;
        }

        if (_controller.isPlayerInAttackRange())
        {
            _controller.CurrentState = new AttackState(_controller);
            return;
        }

        _controller.agent.SetDestination(_controller.player.position);
    }
    public override void OnExit()
    {
        Debug.Log("Stop chasing!");
    }
}
