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
        Vector3 newRingPos = new Vector3(_controller.transform.position.x, _controller.transform.position.y + 1.0f, _controller.transform.position.z);
        GameObject newRing = GhostController.Instantiate(_controller.greenProjectileAttack, newRingPos, Quaternion.Euler(-90, 0, 0));
        resetAttack();
    }

    public override void SpecialAttack()
    {
        Vector3 pos = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up) * _controller.transform.forward * Random.Range(10, 15);
        pos += _controller.transform.position;
        pos.y = _controller.transform.position.y;
        GhostController.Instantiate(_controller.greenSpecialAttack, pos, Quaternion.identity);
        resetAttack();
    }
}
