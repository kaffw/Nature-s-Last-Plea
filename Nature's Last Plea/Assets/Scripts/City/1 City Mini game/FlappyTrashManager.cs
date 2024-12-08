using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FlappyTrashManager : MonoBehaviour
{
    public GameObject[] trashCans;
    public GameObject[] spawnPoints;

    void Start()
    {
        int[] numbers = { 0, 1, 2 };
        int[] randomized = numbers.OrderBy(x => Random.value).ToArray();

        for (int i = 0; i < 3; i++)
        {
            //Instantiate(trashCans[i], spawnPoints[randomized[i]].transform.position, transform.rotation);
            trashCans[i].transform.position = spawnPoints[randomized[i]].transform.position;
        }
    }
}