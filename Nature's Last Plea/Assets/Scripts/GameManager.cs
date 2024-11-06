using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gamePauseObject;

    public GameObject[] pauseStateObjects = new GameObject[4];

    private bool isPaused = false;
    private int prevKey = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.P)) GamePause();

        if (isPaused)
        {
            //Debug.Log("Game Paused");

            if (Input.GetKeyDown(KeyCode.Alpha1))//&& prevKey != 1 )
            {
                prevKey = 1;

                SetPauseState(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))// && prevKey != 2 )
            {
                prevKey = 2;

                SetPauseState(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))//&& prevKey != 3 )
            {
                prevKey = 3;

                SetPauseState(2);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))// && prevKey != 4 )
            {
                prevKey = 4;

                SetPauseState(3);
            }
        }
    }

    public void GamePause() //press P or by button
    {
        //pause canvas set active true... if any
        Time.timeScale = (Time.timeScale > 0) ? 0 : 1; // Pause/Unpause
        isPaused = Time.timeScale == 0;
        gamePauseObject.SetActive(Time.timeScale == 0);
        SetPauseState(0);
    }

    private void SetPauseState(int index)
    {
        for (int i = 0; i < pauseStateObjects.Length; i++)
        {
            pauseStateObjects[i].SetActive(i == index);
        }
    }

    public void OnClickButtonState1()
    {
        if (isPaused) SetPauseState(0);
    }

    public void OnClickButtonState2()
    {
        if (isPaused) SetPauseState(1);
    }

    public void OnClickButtonState3()
    {
        if (isPaused) SetPauseState(2);
    }

    public void OnClickButtonState4()
    {
        if(isPaused) SetPauseState(3);
    }
}
