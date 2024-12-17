using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMG2ItemBehaviour : MonoBehaviour
{
    public GameObject host;

    void Start()
    {
        host = GameObject.Find("Forest Minigame # 2(Clone)");
    }

    void Update()
    {
        if(host == null)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}
