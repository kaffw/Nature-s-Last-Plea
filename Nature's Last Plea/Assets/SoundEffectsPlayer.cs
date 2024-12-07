using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    public AudioSource AudSrc;
    public AudioClip sfx1;

    public void Button1()
    {
        AudSrc.clip = sfx1;
        AudSrc.Play();
    }
    public void Button2()
    {
        AudSrc.clip = sfx1;
        AudSrc.Play();
    }
    public void Button3()
    {
        AudSrc.clip = sfx1;
        AudSrc.Play();
    }
    public void Button4()
    {
        AudSrc.clip = sfx1;
        AudSrc.Play();
    }
}
