using System.Collections;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    //private static int totalLeaves = 0;

    private Renderer leafRenderer; // Renderer for fading out
    private PolygonCollider2D leafCollider; // Collider to disable when fading starts
    public float moveUpDistance = 1.0f; // Distance the object will move up
    public float fadeDuration = 1.5f; // Duration of the fade-out effect

    //public AudioClip removeLeafSFX; // Sound effect for removing a leaf //9
    //private AudioSource audioSource;
    
    AudioSource audSFX;

    public GameObject tutorial;

    void Start()
    {
        audSFX = transform.Find("AudSrc").GetComponent<AudioSource>();
        tutorial = GameObject.Find("L3M2 Tutorial");

        leafRenderer = GetComponent<Renderer>();
        leafCollider = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        audSFX.volume = AudioVolumeManager.sfxGlobalVolume;
    }

    private void OnMouseDown()
    {
        // Perform a raycast to detect all objects under the mouse position

        if(tutorial == null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, Vector2.zero);  // Detect all objects under the mouse position

            foreach (RaycastHit2D hit in hits)
            {
                // Only interact with objects that have a trigger collider
                if (hit.collider.isTrigger && hit.collider.CompareTag("GrateTrash"))
                {
                    StartCoroutine(PickUpEffect());  // Trigger the effect only if conditions are met
                    //audioSource.PlayOneShot(removeLeafSFX);
                    //am.PlaySFX(9);
                    audSFX.Play();
                    break;  // Exit loop once the effect is triggered for the first valid object
                }
            }
        }
    }

    private IEnumerator PickUpEffect()
    {
        leafCollider.enabled = false;

        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + Vector3.up * moveUpDistance;
        float elapsedTime = 0;

        Color startColor = leafRenderer.material.color;

        while (elapsedTime < fadeDuration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / fadeDuration);

            float alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            leafRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        leafRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b, 0);
        transform.position = endPosition;

        SpawnManager.totalLeaves--;

        Destroy(gameObject);

    }
}