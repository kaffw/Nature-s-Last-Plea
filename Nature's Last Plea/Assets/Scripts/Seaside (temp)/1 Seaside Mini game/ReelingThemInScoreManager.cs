using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ReelingThemInScoreManager : MonoBehaviour
{
    public TextMeshPro text;
    public GameObject victoryText;

    public float currentScore;
    public float maxScore;

    public GameObject trash;
    public GameObject trashCounter;

    public GameObject miniGameObject;
    public FishingRodBehaviour fishingRodBehaviour;
    void Start()
    {
        text = GetComponent<TextMeshPro>();

        InstantiateTrash();
    }

    private void InstantiateTrash()
    {
        float max = Random.Range(2, 5);
        for (int i = 0; i < max; i++)
        {
            GameObject newTrash = Instantiate(trash, new Vector2(trashCounter.transform.position.x + Random.Range(-6f, 6f), trashCounter.transform.position.y + Random.Range(-3f, 1f)), transform.rotation); //+ Random.Range(-6f, 1f))
            newTrash.transform.SetParent(trashCounter.transform);
        }

        trashCounter = GameObject.Find("Trash Counter");
        maxScore = trashCounter.transform.childCount;
        UpdateScore();
    }
    private void UpdateScore()
    {
        string currS, maxS;
        currS = currentScore.ToString();
        maxS = maxScore.ToString();
        text.text = currS + "/" + maxS;

        if (currS == maxS)
        {
            StartCoroutine(WinMiniGame());
        }
    }
    public void AddScore()
    {
        currentScore++;
        UpdateScore();
    }

    private IEnumerator WinMiniGame()
    {
        //win cutscene etc...
        fishingRodBehaviour.isDisabled = true;
        victoryText.SetActive(true);
        yield return new WaitForSeconds(3f);

        PlayerController playerControl = GameObject.Find("Char (temp)").gameObject.GetComponent<PlayerController>();
        playerControl.inAction = false;

        Destroy(miniGameObject);
        yield return null;
    }
}
