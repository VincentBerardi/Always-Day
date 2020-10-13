using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightAbsorbBar : MonoBehaviour
{
    public Image lightAbsorbBarImg;

    public float LightAbsorbBarValue { get; set; } = 100.0f;

    // Start is called before the first frame update
    void Awake()
    {
        lightAbsorbBarImg.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        LightAbsorbBarProgress(5.0f * Time.deltaTime);
    }

    public void LightAbsorbBarProgress(float lightAbsorbFillValue)
    {
        float fillAmount = lightAbsorbFillValue / 100.0f;
        lightAbsorbBarImg.fillAmount -= fillAmount;
    }
}
