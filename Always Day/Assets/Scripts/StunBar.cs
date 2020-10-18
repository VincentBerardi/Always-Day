using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StunBar : MonoBehaviour
{
    public Image stunBarImg;
    public GameObject starsFX;

    public float StunBarValue { get; set; } = 0.0f;

    private GhostController _ghost;

    // Start is called before the first frame update
    void Awake()
    {
        stunBarImg.enabled = false;
        _ghost = this.gameObject.GetComponentInParent<GhostController>();
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
        {
            stunBarImg.fillAmount = 0.0f;
            stunBarImg.enabled = false;
            _ghost.CurrentState = new StunnedState(_ghost, starsFX);
        }
    }
}
