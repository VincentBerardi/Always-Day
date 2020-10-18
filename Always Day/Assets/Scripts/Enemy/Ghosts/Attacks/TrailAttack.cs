using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailAttack : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 5.0f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(15, Vector3.right);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.Die(GameObject.Find("BlueRestart 2").transform.position);
        }
    }
}
