using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOrderLayerManager : MonoBehaviour
{
    public GameObject player;
    private SpriteRenderer playerSR;

    void Start()
    {
        playerSR = player.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Behind"))
        {
            playerSR.sortingOrder = 2;

            SpriteRenderer objSR = other.gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>();

            Color color = objSR.color;
            color.a = 0.39f;
            objSR.color = color;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Behind"))
        {
            playerSR.sortingOrder = 4;

            SpriteRenderer objSR = other.gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>();

            Color color = objSR.color;
            color.a = 1f;
            objSR.color = color;
        }
    }
}

/*
void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerSR.sortingOrder = 2;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerSR.sortingOrder = 4;
        }
    }
*/