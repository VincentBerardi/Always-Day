using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyState : State
{
    protected GhostController _controller;

    public BaseEnemyState(GhostController controller) : base(controller)
    {
        _controller = controller;
    }

    public override void Update() { }
}
