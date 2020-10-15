using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private GhostController _target;

    public AttackState(StateMachine stateMachine, GameObject target) : base(stateMachine)
    {
        _target = target.GetComponent<GhostController>();
    }

    public override void OnEnter()
    {
        Debug.Log("Start attacking!");
    }
    public override void Update()
    {
        _target.agent.SetDestination(_target.transform.position);
        _target.transform.LookAt(_target.player);

        if (!_target.alreadyAttacked)
        {
            _target.ShootProjectile();
        }
    }

    public override void OnExit()
    {
        Debug.Log("Stop attacking!");
    }
}
