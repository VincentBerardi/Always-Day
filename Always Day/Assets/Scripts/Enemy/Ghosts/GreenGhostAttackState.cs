using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GreenGhostAttackState : AttackState
{
    public GreenGhostAttackState(GhostController controller) : base(controller)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Entering Green Ghost Attack State");
    }

    public override void OnExit()
    {
        base.OnExit();
        Debug.Log("Exiting Green Ghost Attack State");
    }

    public override void ShootProjectile()
    {
        Vector3 newRingPos = new Vector3(_controller.transform.position.x, 0.5f, _controller.transform.position.z);
        GameObject newRing = GhostController.Instantiate(_controller.greenProjectileAttack, newRingPos, Quaternion.Euler(-90, 0, 0));

        resetAttack();
    }

    public override void SpecialAttack()
    {
        resetAttack();
    }
}
