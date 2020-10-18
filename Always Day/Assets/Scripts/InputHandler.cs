using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    //For logic of stun bar progress

    void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        CheckInputs();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main Scene 2");
    }

    void CheckInputs()
    {
        // Player controls
        if (playerController)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                playerController.Move();
                playerController.animator.SetBool("isRunning", true);
            }
            else
            {
                playerController.animator.SetBool("isRunning", false);
            }

            if (Input.GetButtonDown("Jump"))
                playerController.Jump();

            if (Input.GetMouseButton(0))
                playerController.LockOnToTarget();
            else
            {
                playerController.animator.SetBool("isAttacking", false);
                playerController.electricity.SetActive(false);
                foreach (StunBar stunBar in playerController.ghostsStunBars)
                {
                    if (!stunBar.StunBarImg)
                    {
                        continue;
                    }

                    stunBar.StunBarImg.fillAmount = 0.0f;
                    stunBar.StunBarImg.enabled = false;
                }
            }
        }
    }
}
