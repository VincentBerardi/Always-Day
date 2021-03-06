﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    public GameObject respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player")) {
            if(other.transform.GetComponent<PlayerController>().isDead != true)
            other.transform.GetComponent<PlayerController>().Die(respawnPoint.transform.position);
        }
    }
}
