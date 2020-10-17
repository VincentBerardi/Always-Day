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
        GameObject ring = _controller.GetComponentInChildren<ParticleSystem>().gameObject;
        Vector3 newRingPos = new Vector3(_controller.transform.position.x, 0.5f, _controller.transform.position.z);
        GameObject newRing = GhostController.Instantiate(ring, newRingPos, Quaternion.Euler(-90, 0, 0));
        newRing.AddComponent<ExpandingRing>();

        resetAttack();
    }

    public override void SpecialAttack()
    {
        resetAttack();
    }
}
