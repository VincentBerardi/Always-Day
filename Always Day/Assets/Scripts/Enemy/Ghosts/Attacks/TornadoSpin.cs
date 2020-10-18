using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoSpin : MonoBehaviour
{
    public Transform tornadoCenter;
    public float pullForce = 700;
    public float refreshRate = 2;
    public GameObject player;
    public float chaseSpeed = 7.0f;
    private bool _shouldChase = true;
    private Vector3 _playerInitPos;

    private void Start()
    {
        player = GameObject.Find("Player");
        _playerInitPos = player.transform.position;
        Destroy(this.GetComponentInParent<Transform>().gameObject, 10.0f);
    }

    private void Update()
    {
        if (_shouldChase)
        {
            this.gameObject.GetComponentInParent<Transform>().transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, chaseSpeed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _shouldChase = false;
            StartCoroutine(pullObject(other, true));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _shouldChase = false;
            StartCoroutine(pullObject(other, false));
        }
    }

    IEnumerator pullObject(Collider x, bool shouldPull)
    {
        if (!shouldPull)
        {
            yield return null;
        }

        Vector3 forceDir = tornadoCenter.position - x.transform.position;
        x.GetComponent<Rigidbody>().AddForce(forceDir.normalized * pullForce * Time.deltaTime);
        yield return refreshRate;
        StartCoroutine(pullObject(x, shouldPull));
    }
}
