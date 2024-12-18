using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gamePauseObject;

    public GameObject[] pauseStateObjects = new GameObject[4];

    private bool isPaused = false;
    private int prevKey = 0;

    PlayerController auroraController;

    void Awake()
    {
        auroraController = GameObject.Find("Aurora").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) GamePause(); //Input.GetKeyDown(KeyCode.Tab) || 

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
        if(!VirtualCameraManager.inMinigame)
        {
            //Disable player movement
            isPaused = (isPaused == true) ? false : true;
            auroraController.inAction = isPaused;
            auroraController.DisableMovementUponInteraction();
            gamePauseObject.SetActive(isPaused);

            SetPauseState(0);
        }
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
        if (isPaused && !VirtualCameraManager.inMinigame) SetPauseState(0);
    }

    public void OnClickButtonState2()
    {
        if (isPaused && !VirtualCameraManager.inMinigame) SetPauseState(1);
    }

    public void OnClickButtonState3()
    {
        if (isPaused && !VirtualCameraManager.inMinigame) SetPauseState(2);
    }

    public void OnClickButtonState4()
    {
        if(isPaused && !VirtualCameraManager.inMinigame) SetPauseState(3);
    }

    public void OnClickHome()
    {
        if(!VirtualCameraManager.inMinigame) SceneManager.LoadScene("Main Menu");
    }
}
