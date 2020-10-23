using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShadow : MonoBehaviour
{
    public GameObject _dropShadow;

    private void Start()
    {
        _dropShadow = Instantiate(_dropShadow, Vector3.zero, Quaternion.identity);
        _dropShadow.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

        if (GetComponent<PlayerController>().isGrounded)
        {
            _dropShadow.SetActive(false);
            return;
        }

        _dropShadow.SetActive(false);

        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, -Vector3.up, out hit, 3.0f))
        {
            _dropShadow.SetActive(true);
            _dropShadow.transform.position = hit.point + new Vector3(0, 0.2f, 0);
        }
    }
}
