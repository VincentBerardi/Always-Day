using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 10.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.GetStunned();
        }
    }
}
