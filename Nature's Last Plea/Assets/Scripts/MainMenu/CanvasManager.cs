using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public GameObject mainMenuCanvas, optionCanvas, selectLevelCanvas;
    
    public static bool level1Unlocked, level2Unlocked, level3Unlocked;

    private void Start()
    {
        if (level1Unlocked == false)
        {
            level1Unlocked = true;
            level2Unlocked = false;
            level3Unlocked = false;
        }
    }
    public void Option()
    {
        mainMenuCanvas.SetActive(false);
        selectLevelCanvas.SetActive(false);

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


        selectLevelCanvas.SetActive(true);
    }

    public void BackButtonSelectLevel()
    {
        mainMenuCanvas.SetActive(true);

        selectLevelCanvas.SetActive(false);
    }

    public void EnterLevel1()
    {
        if (level1Unlocked) SceneManager.LoadScene(1);
        else
        {
            Debug.Log("Level 1 locked");
            //manage here if level is locked
        }
    }
    public void EnterLevel2()
    {
        if (level2Unlocked) SceneManager.LoadScene(2);
        else
        {
            Debug.Log("Level 2 locked");
            //manage here if level is locked
        }
    }
    public void EnterLevel3()
    {
        if (level3Unlocked) SceneManager.LoadScene(3);
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
