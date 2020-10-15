using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    //For logic of stun bar progress
    public StunBar stunBar;

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

            if (Input.GetMouseButton(0))
                playerController.LockOnToTarget();
            else
            {
                stunBar.stunBarImg.fillAmount = 0.0f;
                stunBar.stunBarImg.enabled = false;
            }
        }
    }
}
