﻿using System.Collections;
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
        _controller.GetComponent<Animator>().Play("Ghost_Idle");
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
            switch (_controller.ghostType)
            {
                case GhostController.GhostType.RED:
                    _controller.CurrentState = new RedGhostAttackState(_controller);
                    break;
                case GhostController.GhostType.BLUE:
                    _controller.CurrentState = new BlueGhostAttackState(_controller);
                    break;
                case GhostController.GhostType.GREEN:
                    _controller.CurrentState = new GreenGhostAttackState(_controller);
                    break;
            }
        }

        _controller.agent.SetDestination(_controller.player.position);
    }
    public override void OnExit()
    {
        Debug.Log("Stop chasing!");
    }
}
