using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObeliskController : MonoBehaviour
{
    public float nearRadius;
    Vector3 lightObeliskPos;
    public float emissionIntensity;
    public float emissionLossRate;
    public GameObject player;
    Vector3 playerPos;

    public Renderer renderer;

    public Material mat;
    Color color;

    public LightAbsorbBar lightAbsorbBar;

    // Start is called before the first frame update
    void Start()
    {
        nearRadius = 0.8f;
        emissionLossRate = 0.1f;
        lightObeliskPos = transform.position;
        playerPos = player.transform.position;
        color = mat.color;
        emissionIntensity = 3.416924f;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;

        if(Math.Abs(lightObeliskPos.magnitude - playerPos.magnitude) <= nearRadius )
            PlayerIsNearEnoughToAbsorbLight();
    }

    private void PlayerIsNearEnoughToAbsorbLight()
    {
        float amountOfLightAbsorbed = 5.0f * Time.deltaTime;
        lightAbsorbBar.enabled = true;
        lightAbsorbBar.LightAbsorbBarProgress(amountOfLightAbsorbed);
        
        Debug.Log(emissionIntensity);
        if (emissionIntensity > 0.8f)
        {
            emissionIntensity -= Time.deltaTime * emissionLossRate;
            renderer.material.SetColor("_EmissionColor", color * emissionIntensity);
            renderer.UpdateGIMaterials();
        }
    }
}
