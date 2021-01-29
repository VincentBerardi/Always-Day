using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    public GameObject electricity;
    public Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        electricity.SetActive(false);
        animator.SetBool("isGrounded", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
