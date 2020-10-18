using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShadow : MonoBehaviour
{
    private GameObject _dropShadow;

    private void Start()
    {
        _dropShadow = GameObject.Find("DropShadow");
        _dropShadow.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

        // if (GetComponent<PlayerController>().isGrounded)
        // {
        //     _dropShadow.SetActive(false);
        //     return;
        // }

        // RaycastHit hit;
        // if (Physics.Raycast(new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z), -Vector3.up, out hit, 1f))
        // {
        //     Debug.DrawRay(this.transform.position, -Vector3.up * hit.distance, Color.yellow, Mathf.Infinity);
        //     _dropShadow.SetActive(true);
        //     _dropShadow.transform.position = new Vector3(this.transform.position.x, hit.transform.position.y, this.transform.position.z);
        // }
    }
}
