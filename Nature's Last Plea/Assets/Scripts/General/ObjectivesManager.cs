using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{
    public GameObject[] objectives;

    public Transform[] spawnLocations;

    void Start()
    {
        List<int> availableIndices = new List<int>();
        for (int i = 0; i < spawnLocations.Length; i++)
        {
            availableIndices.Add(i);
        }

        for (int i = 0; i < objectives.Length; i++)
        {
            if (availableIndices.Count == 0)
            {
                Debug.LogWarning("Not enough spawn locations for all objectives.");
                break;
            }

            int randIndex = Random.Range(0, availableIndices.Count);
            int spawnIndex = availableIndices[randIndex];

            objectives[i].transform.position = spawnLocations[spawnIndex].position;

            availableIndices.RemoveAt(randIndex);
        }
    }

    public void ShowLocation(int index)
    {
        Debug.Log(objectives[index].transform.position);
    }
}
