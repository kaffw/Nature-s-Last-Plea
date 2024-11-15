using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{
    public GameObject[] objectives;
    //public GameObject[] objectivesInList;

    public Transform[] spawnLocations;

    void Start()
    {
        for (int i = 0; i < objectives.Length; i++)
        {
            int rand = Random.Range(0, spawnLocations.Length);
            objectives[i].transform.position = spawnLocations[rand].position;
        }
    }

    public void ShowLocation(int index)
    {
        Debug.Log(objectives[index].transform.position);
    }
}

//objectives[i].transform.position = new Vector2(i + 2, i + 2);