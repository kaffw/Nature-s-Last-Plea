using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gamePauseObject;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) GamePause();
    }
    public void GamePause() //press P or by button
    {
        //pause canvas set active true... if any
        Time.timeScale = (Time.timeScale > 0) ? 0 : 1; // Pause/Unpause
        gamePauseObject.SetActive(Time.timeScale == 0);

    }
}
