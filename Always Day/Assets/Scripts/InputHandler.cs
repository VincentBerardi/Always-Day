using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    // For testing
    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();    
    }

    void Update()
    {
        CheckInputs();
    }

    void CheckInputs()
    {
        // For testing
        if (Input.GetKeyDown(KeyCode.Alpha1) && audioManager != null)
            audioManager.Play("test");

        if (Input.GetKeyDown(KeyCode.Alpha2) && audioManager != null)
            audioManager.Stop("test");
    }
}
