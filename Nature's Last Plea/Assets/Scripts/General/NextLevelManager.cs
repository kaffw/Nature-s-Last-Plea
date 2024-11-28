using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelManager : MonoBehaviour
{
    private bool oneInstance = false;
    GameTimerManager gtm;

    void Awake()
    {
        gtm = GameObject.Find("GameTimerManager").GetComponent<GameTimerManager>();
    }

    void Update()
    {
        if (transform.childCount == 0 && !oneInstance)
        {
            oneInstance = true;
            Debug.Log("Unlocks next level");

            if (CanvasManager.unlockedLevels == SceneManager.GetActiveScene().buildIndex) CanvasManager.unlockedLevels++;
            else Debug.Log("Area has already been cleared");

            //SceneManager.LoadScene(0);
            StartCoroutine(gtm.VictoryCutscene());
        }
    }
}

/*

CanvasManager.unlockedLevels == SceneManager.GetActiveScene().buildIndex;

 */