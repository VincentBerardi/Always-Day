using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackState : BaseEnemyState
{
    public AttackState(GhostController controller) : base(controller)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("Start attacking!");
        _controller.GetComponent<Animator>().Play("Ghost_Attack");
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

    public abstract void ShootProjectile();
    public abstract void SpecialAttack();

    public virtual void resetAttack()
    {
        _controller.alreadyAttacked = true;
        _controller.Invoke(nameof(_controller.ResetAttack), _controller.timeBetweenAttacks);
    }


}
