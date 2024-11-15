using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasideTrashBehaviour : MonoBehaviour
{
    public bool isCaught = false;
    public GameObject parent;
    void Update()
    {
        if (isCaught)
        {
            transform.position = parent.transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FishingHook"))
        {
            parent = other.gameObject;
            isCaught = true;
        }
    }
}
