using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeReceiver : MonoBehaviour
{
    public float bgmGameLoopVolume;
    public Slider bgmGameSlider;
    
    void Start()
    {
        bgmGameSlider.value = AudioVolumeManager.bgmGlobalVolume;// bgmGameLoopVolume;
    }

    void Update()
    {
        AudioVolumeManager.bgmGlobalVolume = bgmGameSlider.value;
    }
}
