using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    private GhostController _target;

    public ChaseState(StateMachine stateMachine, GameObject target) : base(stateMachine)
    {
        _target = target.GetComponent<GhostController>();
    }

    public override void OnEnter()
    {
        Debug.Log("Start chasing!");
    }
    public override void Update()
    {
        _target.agent.SetDestination(_target.player.position);
    }
    public override void OnExit()
    {
        Debug.Log("Stop chasing!");
    }
}
