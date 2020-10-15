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
        //stunBarImg.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        StunBarProgress(5.0f * Time.deltaTime);
    }

    public void StunBarProgress(float stunBarFillValue)
    {
        float fillAmount = stunBarFillValue / 100.0f;
        stunBarImg.fillAmount += fillAmount;
    }
}
