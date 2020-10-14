using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        CheckInputs();
    }

    void CheckInputs()
    {
        // Player controls
        if (playerController)
        { 
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                playerController.Move();

            if (Input.GetButtonDown("Jump") && playerController.isGrounded)
                playerController.Jump();
        }
    }
}
