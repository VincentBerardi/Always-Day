using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    private float offset;

    void Start()
    {
        player = GameObject.Find("Player");
        offset = (player.transform.position + transform.position).magnitude;
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(30, 45, 0);
        transform.position = player.transform.position - (Quaternion.Euler(30, 45, 0) * Vector3.forward * offset );
    }
}
