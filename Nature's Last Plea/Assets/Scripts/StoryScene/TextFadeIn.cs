using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeIn : MonoBehaviour
{
    private Text uiText;

    public float fadeDuration = 1f;

    void Start()
    {
        uiText = GetComponent<Text>();

        Color color = uiText.color;
        color.a = 0f;
        uiText.color = color;

        StartCoroutine(FadeTextIn());
    }

    private IEnumerator FadeTextIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            Color color = uiText.color;
            color.a = alpha;
            uiText.color = color;
            yield return null;
        }
    }

    public IEnumerator FadeTextOut()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(1 - (elapsedTime / fadeDuration));
            Color color = uiText.color;
            color.a = alpha;
            uiText.color = color;
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
