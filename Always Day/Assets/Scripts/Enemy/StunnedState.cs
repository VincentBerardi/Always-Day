using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StunnedState : BaseEnemyState
{
    private float _stunnedTime = 5.0f;
    private float _timer = 0.0f;

    public StunnedState(GhostController controller) : base(controller)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("Entered the stunned state!");
        _controller.GetComponent<Animator>().Play("Ghost_Stunned");
        _controller.GetComponent<NavMeshAgent>().isStopped = true;
    }

    public override void Update()
    {
        if (_timer >= _stunnedTime)
        {
            _controller.CurrentState = new PatrolState(_controller);
        }

        _timer += Time.deltaTime;
    }

    public override void OnExit()
    {
        Debug.Log("Exited the stunned state!");
        _controller.GetComponent<NavMeshAgent>().isStopped = false;

    }
}
