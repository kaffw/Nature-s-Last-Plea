using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMG2ItemBehaviour : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}
