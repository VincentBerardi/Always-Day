using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float shootInterval = 10f;
    public float projectileForce = 1f;
    public GameObject projectile;
    public bool alreadyAttacked = false;
    private Vector3 shootSource;

    private void Awake()
    {
        shootSource = transform.Find("Source").transform.position;
    }

    private void Update()
    {
        if (!alreadyAttacked)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Rigidbody rb = Instantiate(projectile, shootSource, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * projectileForce, ForceMode.Impulse);
        alreadyAttacked = true;
        Invoke(nameof(ResetAttack), shootInterval);
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }


}
