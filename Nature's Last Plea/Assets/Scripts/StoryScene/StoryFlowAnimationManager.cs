using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryFlowAnimationManager : MonoBehaviour
{
    public Animator
            auroraAnim,
            frogAnim,
            landscapeAnim;

    public GameObject darkenGO;

    public float timer;

    private float
            entryDuration = 1.5f,
            talkDuration = 0.9f,
            darkenDuration = 7f;

    private bool darkenCalled;

    void Start()
    {
        darkenCalled = false;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= entryDuration)
        {
            auroraAnim.SetTrigger("AuroraTalks");
        }

        if(timer >= entryDuration + talkDuration)
        {
            frogAnim.SetTrigger("FrogTalks");
        }

        if(timer >= entryDuration + talkDuration + talkDuration && !darkenCalled)
        {
            StartCoroutine(Darkens());
            darkenCalled = true;
        }

        if(timer >= darkenDuration)
        {
        //aurora runs to the other side
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
        darkenGO.SetActive(false);
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
