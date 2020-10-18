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
    public string name;
    public BigLightObeliskController bigLightObelisk;

    public Renderer renderer;

    public Material mat;
    Color color;
    Light pointLight;
    float pointLightLossRate;

    // Start is called before the first frame update
    void Start()
    {
        emissionLossRate = 0.25f;
        lightObeliskPos = transform.position;
        color = mat.color;
        pointLight = GetComponent<Light>();
        pointLightLossRate = 0.15f;
        emissionIntensity = 3.0f;
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
        if (emissionIntensity > 0.0f)
        {
            emissionIntensity -= Time.deltaTime * emissionLossRate;
            pointLight.range -= Time.deltaTime * pointLightLossRate;
            pointLight.intensity -= Time.deltaTime * pointLightLossRate;
            renderer.material.SetColor("_EmissionColor", color * emissionIntensity);
            renderer.UpdateGIMaterials();
        }
        else 
        {
            switch (name)
            {
                case "Red":
                    bigLightObelisk.isRedLightActivated = true;
                    break;
                case "Blue":
                    bigLightObelisk.isBlueLightActivated = true;
                    break;
                case "Green":
                    bigLightObelisk.isGreenLightActivated = true;
                    break;
            }
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
