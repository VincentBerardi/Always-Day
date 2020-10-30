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

    private void OnTriggerStay(Collider other)
    {
        player = other.gameObject.GetComponent<PlayerController>();
        if (player && !player.gotLight)
            canAbsorb = true;
        else
            canAbsorb = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
            canAbsorb = false;
    }
}
