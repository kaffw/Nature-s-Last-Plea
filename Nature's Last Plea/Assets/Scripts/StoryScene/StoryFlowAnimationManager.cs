using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryFlowAnimationManager : MonoBehaviour
{
    public Animator
            auroraAnim,
            frogAnim,
            landscapeAnim;

    public GameObject darkenGO, shockExpGO;
    public GameObject[] dialogueLineGO;
    private bool line1 = false, line2= false, line3 = false;

    public float timer;

    private float
            entryDuration = 1.5f,
            talkDuration = 0.9f,
            darkenDuration = 7f,
            exitDuration = 9f;

    private bool darkenCalled;

    void Start()
    {
        darkenCalled = false;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(!line1)
        {
            dialogueLineGO[0].SetActive(true);
            line1 = true;
        }

        if(timer >= entryDuration)
        {
            if(!line2 && timer >= entryDuration + 1f)
            {
                TextFadeIn fade = dialogueLineGO[0].GetComponent<TextFadeIn>();
                StartCoroutine(fade.FadeTextOut());
                dialogueLineGO[1].SetActive(true);
                line2 = true;
            }

            auroraAnim.SetTrigger("AuroraTalks");
        }

        if(timer >= entryDuration + talkDuration)
        {
            frogAnim.SetTrigger("FrogTalks");
        }

        if(!line3 && timer >= 6f)
        {
            TextFadeIn fade = dialogueLineGO[1].GetComponent<TextFadeIn>();
            StartCoroutine(fade.FadeTextOut());
            dialogueLineGO[2].SetActive(true);
            line3 = true;
        }

        if(timer >= entryDuration + talkDuration + talkDuration && !darkenCalled)
        {
            shockExpGO.SetActive(true);
            StartCoroutine(Darkens());
            darkenCalled = true;
        }

        if(timer >= darkenDuration)
        {            
            auroraAnim.SetTrigger("AuroraExits");
            landscapeAnim.SetTrigger("ParallaxExit");
        }

        if(timer >= exitDuration)
        {
            StartCoroutine(ExitScene());
        }
    }

    IEnumerator Darkens()
    {
        Image img = darkenGO.GetComponent<Image>();
        
        Color startColor = img.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 230f / 255f);
        Color flashColor = new Color(startColor.r, startColor.g, startColor.b, 180f / 255f);

        float duration = 1f;

        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            img.color = Color.Lerp(startColor, endColor, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        img.color = endColor;
        yield return new WaitForSeconds(1f);

        //Flash
        img.color = flashColor;
        yield return new WaitForSeconds(.1f);
        img.color = endColor;
        yield return new WaitForSeconds(.2f);
        img.color = flashColor;
        yield return new WaitForSeconds(.1f);
        img.color = endColor;

        yield return new WaitForSeconds(.2f);
        
        float fadeOutDuration = 1f;
        timeElapsed = 0f;

        while (timeElapsed < fadeOutDuration)
        {
            img.color = Color.Lerp(endColor, startColor, timeElapsed / fadeOutDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        img.color = startColor;
        Debug.Log(timer);
        shockExpGO.SetActive(false);
        darkenGO.SetActive(false);
    }

    IEnumerator ExitScene()
    {
        //fade
        darkenGO.SetActive(true);

        Image img = darkenGO.GetComponent<Image>();
        
        Color startColor = img.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 255f / 255f);

        float duration = 2f;

        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            img.color = Color.Lerp(startColor, endColor, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        img.color = endColor;
        SceneManager.LoadScene("Main Menu");
    }
}
/*
0-1.5s
aurora entry
frog entry
landscape entry

greet 1 s

frog talk 0.9 s
aurora talk 0.9s
*/
