using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public float fallSpeed = 2f; // Speed at which the item falls
    private float bottomY; // Bottom boundary for destruction

    public void SetBounds(float bottomBoundary)
    {
        bottomY = bottomBoundary; // Set the bottom boundary
    }

    void Update()
    {
        // Move the item downward
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Destroy the item if it reaches the bottom boundary
        if (transform.position.y <= bottomY)
        {
            Destroy(gameObject);
        }
    }
}