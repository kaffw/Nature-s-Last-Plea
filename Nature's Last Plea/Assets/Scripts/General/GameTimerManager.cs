using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimerManager : MonoBehaviour
{
    public float gameTimer;
    public GameObject rain;
    public Light2D globalLight;

    public GameObject HUD;
    public GameObject victoryCutscene, defeatCutscene;

    public bool isCalled;
    private float targetIntensity = 0.2f;
    private float transitionDuration = 1f;
    private float intensityStart = 1f;
    private float intensityTime = 1f;

    private bool inCutscene = false;

    public Image timerImage;

    public bool objCompleted;
    
    void Awake()
    {
        rain = GameObject.Find("Rain Particle System");
        globalLight = GameObject.Find("GlobalLight").GetComponent<Light2D>();
        HUD = GameObject.Find("HUD Canvas");
        objCompleted = false;
    }

    void Start()
    {
        gameTimer = 0f;
        isCalled = false;

        rain.SetActive(false);
    }

    void Update()
    {
        gameTimer += Time.deltaTime;

        if(gameTimer <= 180 && !objCompleted) UpdateImage();

        if (gameTimer >= 60 * 1.5 && !isCalled)
        {
            // Start raining
            isCalled = true;
            rain.SetActive(true);

            intensityTime = 0f;
        }

        if (gameTimer >= 60 * 3)
        {
            // Defeat cutscene logic
            StartCoroutine(DefeatCutscene());
        }

        if (intensityTime < transitionDuration)
        {
            intensityTime += Time.deltaTime;
            float lerpedIntensity = Mathf.Lerp(intensityStart, targetIntensity, intensityTime / transitionDuration);
            globalLight.intensity = lerpedIntensity;
        }

        if (inCutscene)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(0);
            }
        }
    }


    public IEnumerator VictoryCutscene()
    {
        //play victory cutscene here
        inCutscene = true;
        rain.SetActive(false);
        globalLight.intensity = 1f;
        victoryCutscene.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
        yield return null;
    }

    public IEnumerator DefeatCutscene()
    {
        //play defeat cutscene here
        inCutscene = true;
        HUD.SetActive(false);
        defeatCutscene.SetActive(true);
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene(0);
        yield return null;
    }

    public void UpdateImage()
    {
        timerImage.fillAmount = gameTimer / 180f;
    }
}
