using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEndMusic : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("end");
    }


}
