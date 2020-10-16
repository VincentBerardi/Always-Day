using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseEnemyState
{
    public AttackState(GhostController controller) : base(controller)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("Start attacking!");
    }

    public override void Update()
    {

        if (!_controller.isPlayerInAttackRange())
        {
            _controller.CurrentState = new ChaseState(_controller);
            return;
        }

        _controller.agent.SetDestination(_controller.transform.position);
        _controller.transform.LookAt(_controller.player);

        if (!_controller.alreadyAttacked)
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    ShootProjectile();
                    break;
                case 1:
                    ShootProjectile();
                    break;
                case 2:
                    SpecialAttack();
                    break;
            }
        }
    }

    public override void OnExit()
    {
        Debug.Log("Stop attacking!");
    }

    public void ShootProjectile()
    {
        switch (_controller.ghostType)
        {
            case GhostController.GhostType.Red:
                Rigidbody rb = GhostController.Instantiate(_controller.projectile, _controller.transform.position + _controller.transform.forward * _controller.projectileStartDist, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(_controller.transform.forward * _controller.projectileForce, ForceMode.Impulse);
                _controller.alreadyAttacked = true;
                _controller.Invoke(nameof(_controller.ResetAttack), _controller.timeBetweenAttacks);
                break;
            case GhostController.GhostType.Green:
                //TODO
                break;
            case GhostController.GhostType.Blue:
                //TODO
                break;
        }
    }

    public void SpecialAttack()
    {
        switch (_controller.ghostType)
        {
            case GhostController.GhostType.Red:
                _controller.rigidBody.isKinematic = false;
                _controller.agent.enabled = false;
                _controller.rigidBody.AddForce(_controller.transform.forward * _controller.rammingForce, ForceMode.Impulse);
                _controller.alreadyAttacked = true;
                _controller.Invoke(nameof(_controller.ResetAttack), _controller.timeBetweenAttacks);
                break;
            case GhostController.GhostType.Green:
                //TODO
                break;
            case GhostController.GhostType.Blue:
                //TODO
                break;
        }
    }
}
