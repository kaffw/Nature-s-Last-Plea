using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioVolumeManager : MonoBehaviour
{
    public static float bgmGlobalVolume;
    public Slider bgmSlider;
    public AudioVolumeReceiver bgmGameSceneVolume;

    Scene currScene;

    void Update()
    {
        currScene = SceneManager.GetActiveScene();

        if (currScene.buildIndex == 0)
        {
            bgmGlobalVolume = bgmSlider.value;
        }
    }
}
