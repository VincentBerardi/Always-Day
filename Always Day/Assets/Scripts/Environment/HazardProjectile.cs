using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardProjectile : MonoBehaviour
{

    [SerializeField]
    string respawnPoint;
    public float destroyTime = 2f; 

    private void Start()
    {
        Invoke(nameof(DestroyDelay), destroyTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (other.transform.GetComponent<PlayerController>().isDead != true)
            {
                other.transform.GetComponent<PlayerController>().Die(GameObject.Find(respawnPoint).transform.position);
                Destroy(gameObject);
            }
        }

    }

    private void DestroyDelay()
    {
        Destroy(gameObject);
    }
}
