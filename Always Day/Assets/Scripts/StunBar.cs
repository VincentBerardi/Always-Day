using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StunBar : MonoBehaviour
{
    public GameObject stunbarCanvas;
    public GameObject starsFX;
    public float StunBarValue { get; set; } = 0.0f;

    private GhostController _ghost;
    private Image _stunBarImg;
    public Image StunBarImg { get { return _stunBarImg; } }

    // Start is called before the first frame update
    void Awake()
    {
        stunbarCanvas = Instantiate(stunbarCanvas, Vector3.zero, Quaternion.identity);
        _stunBarImg = stunbarCanvas.GetComponentsInChildren<Image>()[1];
        _stunBarImg.enabled = false;
        _ghost = this.gameObject.GetComponentInParent<GhostController>();
    }

    // Update is called once per frame
    void Update()
    {
        _stunBarImg.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }

    public void StunBarProgress(float stunBarFillValue)
    {
        float fillAmount = stunBarFillValue / 100.0f;
        _stunBarImg.fillAmount += fillAmount;

        if (_stunBarImg.fillAmount >= 1.0f)
        {
            _stunBarImg.fillAmount = 0.0f;
            _stunBarImg.enabled = false;
            _ghost.CurrentState = new StunnedState(_ghost, starsFX);
        }
    }
}
