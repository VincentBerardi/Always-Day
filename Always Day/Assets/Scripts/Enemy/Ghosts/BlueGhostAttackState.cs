using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGhostAttackState : AttackState
{
    public BlueGhostAttackState(GhostController controller) : base(controller)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Entering Blue Ghost Attack State");
    }

    public override void OnExit()
    {
        base.OnExit();
        Debug.Log("Exiting Blue Ghost Attack State");
    }

    public override void ShootProjectile()
    {
        resetAttack();
    }

    public override void SpecialAttack()
    {
        GhostController.Instantiate(_controller.blueSpecialAttack, _controller.transform.position, Quaternion.identity);
        resetAttack();
    }
}

