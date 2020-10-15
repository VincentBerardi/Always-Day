using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;
    
    //Logic for stun bar progress
    public StunBar stunBar;
    public float stunBarIncrement;

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
            {
                playerController.LockOnToTarget();
                stunBar.stunBarImg.enabled = true;
                stunBar.StunBarProgress(stunBarIncrement * Time.deltaTime);
            }
            else
            {
                stunBar.stunBarImg.fillAmount = 0.0f;
                stunBar.stunBarImg.enabled = false;
            }

        }
    }
}
