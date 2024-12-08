using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    AudioSource musicSource;
    AudioSource sfxSource;
    Scene currScene;

    public AudioClip bgm;
    public AudioClip[] sfx;

    //public Slider bgmVolume;
    //public Slider bgmGameSceneVolume;
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            musicSource = gameObject.AddComponent<AudioSource>();
            sfxSource = gameObject.AddComponent<AudioSource>();
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
        sfxSource.volume = AudioVolumeManager.sfxGlobalVolume;
    }

    public void PlaySFX(int sfxIndex)
    {
        sfxSource.clip = sfx[sfxIndex];
        sfxSource.Play();
    }
}
/*
SFX:
1   -   catch smt
2   -   caught trash
3   -   click button
4   -   drop seed
5   -   drop seed water
6   -   flapibird
7   -   hook trash
8   -   leaves
9   -   remove leaves
10  -   spling drp water
*/