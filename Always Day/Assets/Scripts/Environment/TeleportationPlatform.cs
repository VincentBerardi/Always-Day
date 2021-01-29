using UnityEngine;

public class TeleportationPlatform : MonoBehaviour
{
    public GameObject portal;
    public GameObject mainSpawnPoint;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        portal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gotLight)
            portal.SetActive(true);
        else
            portal.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() && player.gotLight)
            player.Teleport(mainSpawnPoint.transform.position);
    }

    private void OnTriggerExit(Collider other)
    {
        portal.SetActive(false);
    }
}
