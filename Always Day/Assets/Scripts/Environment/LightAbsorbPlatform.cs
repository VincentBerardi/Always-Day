using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAbsorbPlatform : MonoBehaviour
{
    public GameObject lightAbsorb;
    public bool canAbsorb;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        lightAbsorb.SetActive(false);
        canAbsorb = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canAbsorb)
            lightAbsorb.SetActive(true);
        else
            lightAbsorb.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject.GetComponent<PlayerController>();
        //if (other.gameObject.GetComponent<PlayerController>())
        if (player && !player.gotLight)
        {
            Debug.Log("in here");
            canAbsorb = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
            canAbsorb = false;
    }
}
