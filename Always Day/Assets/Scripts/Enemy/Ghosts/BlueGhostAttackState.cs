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
        Rigidbody rb = GhostController.Instantiate(_controller.blueProjectileAttack, _controller.transform.position + _controller.transform.forward * _controller.projectileStartDist, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(_controller.transform.forward * _controller.projectileForce, ForceMode.Impulse);
        resetAttack();
    }

    public override void SpecialAttack()
    {
        // GhostController.Instantiate(_controller.blueSpecialAttack, _controller.transform.position, Quaternion.identity);
        resetAttack();
    }
}

