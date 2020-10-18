using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BigLightObeliskController : MonoBehaviour
{
    public bool isRedLightActivated;
    public bool isBlueLightActivated;
    public bool isGreenLightActivated;

    //Light objects
    public GameObject redSphere;
    public GameObject blueSphere;
    public GameObject greenSphere;
    
    //Blocking path objects
    public GameObject redWall;
    public GameObject blueWall;
    public GameObject greenWall;

    // Start is called before the first frame update
    void Awake()
    {
        isRedLightActivated = false;
        isBlueLightActivated = false;
        isGreenLightActivated = false;

        redSphere.SetActive(false);
        blueSphere.SetActive(false);
        greenSphere.SetActive(false);
        
        redWall.SetActive(false);
        blueWall.SetActive(false);
        greenWall.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (isRedLightActivated)
        {
            redSphere.SetActive(true);
            redWall.SetActive(true);
        }
        if (isBlueLightActivated)
        {
            blueSphere.SetActive(true);
            blueWall.SetActive(true);
        }
        if (isGreenLightActivated)
        {
            greenSphere.SetActive(true);
            greenWall.SetActive(true);
        }

        if (isRedLightActivated && isBlueLightActivated && isGreenLightActivated)
        {
            StartCoroutine(WinningSceneCountdown());
        }

    }

    private IEnumerator WinningSceneCountdown()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("WinningScene");
    }
}
