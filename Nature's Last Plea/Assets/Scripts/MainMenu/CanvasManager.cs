using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject mainMenuCanvas, optionCanvas, selectLevelCanvas, creditsCanvas;
    
    public static bool level1Unlocked, level2Unlocked, level3Unlocked;

    public static int unlockedLevels = 1;

    public Image lvl2img, lvl3backimg, lvl3frontimg;

    private static bool forceLevelSelect = false;

    void Start()
    {
        if(!forceLevelSelect) forceLevelSelect = true;
        else
        {
            SelectLevel();
        }        
    }

    void Update()
    {
        if (unlockedLevels >= 2)
        {
            lvl2img.color = new Color32(255, 255, 255, 255);
        }
        if (unlockedLevels >= 3)
        {
            lvl3backimg.color = new Color32(255, 255, 255, 255);
            lvl3frontimg.color = new Color32(255, 255, 255, 255);
        }
    }

    

    public void Option()
    {
        mainMenuCanvas.SetActive(false);
        selectLevelCanvas.SetActive(false);
        creditsCanvas.SetActive(false);

        optionCanvas.SetActive(true);
    }

    public void BackButtonOption()
    {
        mainMenuCanvas.SetActive(true);

        optionCanvas.SetActive(false);
    }

    public void SelectLevel()
    {
        mainMenuCanvas.SetActive(false);
        optionCanvas.SetActive(false);
        creditsCanvas.SetActive(false);

        selectLevelCanvas.SetActive(true);
    }

    public void BackButtonSelectLevel()
    {
        mainMenuCanvas.SetActive(true);

        selectLevelCanvas.SetActive(false);
    }

    public void Credits()
    {
        mainMenuCanvas.SetActive(false);
        selectLevelCanvas.SetActive(false);
        optionCanvas.SetActive(false);

        creditsCanvas.SetActive(true);
    }

    public void BackButtonCredits()
    {
        mainMenuCanvas.SetActive(true);

        creditsCanvas.SetActive(false);
    }

    public void EnterLevel1()
    {
        //if (level1Unlocked) SceneManager.LoadScene(1);
        if(unlockedLevels >= 1) SceneManager.LoadScene(1);
        else
        {
            Debug.Log("Level 1 locked");
            //manage here if level is locked
        }
    }
    public void EnterLevel2()
    {
        //if (level2Unlocked) SceneManager.LoadScene(2);
        if (unlockedLevels >= 2) SceneManager.LoadScene(2);
        else
        {
            Debug.Log("Level 2 locked");
            //manage here if level is locked
        }
    }
    public void EnterLevel3()
    {
        //if (level3Unlocked) SceneManager.LoadScene(3);
        if (unlockedLevels >= 3) SceneManager.LoadScene(3);
        else
        {
            Debug.Log("Level 3 locked");
            //manage here if level is locked
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
