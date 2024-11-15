using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaplingPlantingManager : MonoBehaviour
{
    public GameObject rock;

    void Start()
    {
        //instantiate rocks randomly
        for (int rcount = 0; rcount < Random.Range(1, 3); rcount++)
        {
            GameObject newRock = Instantiate(rock, Vector3.zero, Quaternion.identity);

            newRock.transform.SetParent(transform, true);

            float x = gameObject.transform.localScale.x;
            float y = gameObject.transform.localScale.y;

            newRock.transform.localPosition = new Vector3(Random.Range(-10/ x, 11/ x), Random.Range(-4 / y, 1 / y), 0);
            //newRock.transform.localScale = Vector3.one;
        }   
        //Random.Range();
    }
}
/*
 x = -10, 10
 y = -4, 0
 */