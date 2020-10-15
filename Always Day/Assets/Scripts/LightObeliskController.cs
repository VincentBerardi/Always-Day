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

    public Renderer renderer;

    public Material mat;
    Color color;

    //If decide to add-on bar later
    //public LightAbsorbBar lightAbsorbBar;

    // Start is called before the first frame update
    void Start()
    {
        emissionLossRate = 0.1f;
        lightObeliskPos = transform.position;
        color = mat.color;
        emissionIntensity = 3.416924f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerIsNearEnoughToAbsorbLight();
    }

    private void PlayerIsNearEnoughToAbsorbLight()
    {
        Collider[] colliders = Physics.OverlapSphere(lightObeliskPos, nearRadius);

        foreach (Collider cd in colliders)
        {
            if (cd.gameObject.GetComponent<PlayerController>())
                DecrementEmissionLight();
        }
    }

    private void DecrementEmissionLight()
    {
        //If decide to add-on bar later
        //float amountOfLightAbsorbed = 5.0f * Time.deltaTime;
        //lightAbsorbBar.enabled = true;
        //lightAbsorbBar.LightAbsorbBarProgress(amountOfLightAbsorbed);

        if (emissionIntensity > 0.8f)
        {
            emissionIntensity -= Time.deltaTime * emissionLossRate;
            renderer.material.SetColor("_EmissionColor", color * emissionIntensity);
            renderer.UpdateGIMaterials();
        }
    }

    /*
    //For testing radius
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, nearRadius);
    }
    /**/
}
