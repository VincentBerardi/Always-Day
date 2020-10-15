using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StunBar : MonoBehaviour
{
    public Image stunBarImg;

    public float StunBarValue { get; set; } = 0.0f;

    // Start is called before the first frame update
    void Awake()
    {
        stunBarImg.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        stunBarImg.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }

    public void StunBarProgress(float stunBarFillValue)
    {
        float fillAmount = stunBarFillValue / 100.0f;
        stunBarImg.fillAmount += fillAmount;

        if (stunBarImg.fillAmount >= 1.0f)
            Debug.Log("Stun Enemy spell");
    }
}
