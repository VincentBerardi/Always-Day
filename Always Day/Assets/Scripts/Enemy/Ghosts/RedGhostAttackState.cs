using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGhostAttackState : AttackState
{
    public RedGhostAttackState(GhostController controller) : base(controller)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Entering red ghost attacking state");
    }
    public override void Update()
    {
        base.Update();
    }

    public override void OnExit()
    {
        base.OnExit();
        Debug.Log("Exiting red ghost attacking state");
    }

    public override void ShootProjectile()
    {
        Rigidbody rb = GhostController.Instantiate(_controller.projectile, _controller.transform.position + _controller.transform.forward * _controller.projectileStartDist, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(_controller.transform.forward * _controller.projectileForce, ForceMode.Impulse);
        resetAttack();
    }

    public override void SpecialAttack()
    {

        _controller.rigidBody.isKinematic = false;
        _controller.agent.enabled = false;
        _controller.rigidBody.AddForce(_controller.transform.forward * _controller.rammingForce, ForceMode.Impulse);
        resetAttack();
    }
}



