using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseEnemyState
{
    public IdleState(GhostController controller) : base(controller)
    {
    }


    public override void OnEnter()
    {
        _controller.GetComponent<Animator>().Play("Ghost_Idle");
    }

    public override void Update()
    {
    }

    public override void OnExit()
    {
    }
}
