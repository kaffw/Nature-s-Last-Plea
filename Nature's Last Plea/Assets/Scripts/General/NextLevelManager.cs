using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelManager : MonoBehaviour
{
    private bool oneInstance = false;

    void Update()
    {
        if (transform.childCount == 0 && !oneInstance)
        {
            oneInstance = true;
            Debug.Log("Unlocks next level");

            if (CanvasManager.unlockedLevels == SceneManager.GetActiveScene().buildIndex) CanvasManager.unlockedLevels++;
            else Debug.Log("Area has already been cleared");

            SceneManager.LoadScene(0);
        }
    }
}

/*

CanvasManager.unlockedLevels == SceneManager.GetActiveScene().buildIndex;

 */