using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInteract : MonoBehaviour
{
    public GameObject text;

    private void Start()
    {
        text = gameObject.transform.GetChild(0).transform.gameObject;
        text.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(false);
        }
    }
}
