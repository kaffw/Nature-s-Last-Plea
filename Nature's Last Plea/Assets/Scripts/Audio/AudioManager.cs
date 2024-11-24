using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    AudioSource musicSource;
    Scene currScene;

    public AudioClip bgm;

    //public Slider bgmVolume;
    //public Slider bgmGameSceneVolume;
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            musicSource = gameObject.AddComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        musicSource.clip = bgm;
        musicSource.loop = true;
        musicSource.Play();
    }

    void Update()
    {
        musicSource.volume = AudioVolumeManager.bgmGlobalVolume;
    }
}
