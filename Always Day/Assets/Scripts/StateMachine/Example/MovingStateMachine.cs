using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStateMachine : MonoBehaviour
{
    StateMachine stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new StateMachine();
        stateMachine.CurrentState = new MoveForwardState(stateMachine, this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.CurrentState.Update();
    }
}
