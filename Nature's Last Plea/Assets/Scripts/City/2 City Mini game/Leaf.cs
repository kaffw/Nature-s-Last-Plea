using System.Collections;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    private static int totalLeaves = 0;
    private Renderer leafRenderer; // Renderer for fading out
    private PolygonCollider2D leafCollider; // Collider to disable when fading starts
    public float moveUpDistance = 1.0f; // Distance the object will move up
    public float fadeDuration = 1.5f; // Duration of the fade-out effect

    void Start()
    {
        // Reset the counter if this is the first leaf spawned
        if (totalLeaves == 0)
        {
            totalLeaves = GameObject.FindGameObjectsWithTag("GrateTrash").Length;
        }

        leafRenderer = GetComponent<Renderer>();
        leafCollider = GetComponent<PolygonCollider2D>(); // Cache the Collider component
    }

    private void OnMouseDown()
    {
        // Start the pick-up effect coroutine
        StartCoroutine(PickUpEffect());
    }

    private IEnumerator PickUpEffect()
    {
        // Disable the Collider to make the leaf non-clickable
        leafCollider.enabled = false;

        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + Vector3.up * moveUpDistance;
        float elapsedTime = 0;

        // Cache the initial color of the object for the fade effect
        Color startColor = leafRenderer.material.color;

        while (elapsedTime < fadeDuration)
        {
            // Move the object up
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / fadeDuration);

            // Fade out the object
            float alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            leafRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the object is fully transparent and at the end position
        leafRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b, 0);
        transform.position = endPosition;

        // Destroy the object
        Destroy(gameObject);
        totalLeaves--;

        // Check if all leaves are destroyed
        if (totalLeaves <= 0)
        {
            Debug.Log("You Win!");
        }
    }
}