using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingHookBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public float reelSpeed = 3f;

    public bool isReturning = false;

    public FishingRodBehaviour fishingPause;
    public ReelingThemInScoreManager scoreManager;

    // Audio variables
    public AudioClip attachTrashSFX; // Sound for attaching trash
    public AudioClip otherSFX;       // Sound for hitting other objects
    private AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fishingPause = GameObject.Find("Fishing Rod").GetComponent<FishingRodBehaviour>();
        scoreManager = GameObject.Find("Reeling Them In Score").GetComponent<ReelingThemInScoreManager>();

        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (!isReturning) rb.velocity = transform.right * reelSpeed;
        else rb.velocity = -transform.right * reelSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border") || other.CompareTag("Log"))
        {
            Debug.Log("Border Reached");
            isReturning = true;

            // Play other object SFX
            PlaySound(otherSFX);
        }

        if (other.CompareTag("Trash"))
        {
            other.transform.SetParent(gameObject.transform);
            isReturning = true;

            // Play trash attachment SFX
            PlaySound(attachTrashSFX);
        }

        if (other.CompareTag("Player"))
        {
            if (gameObject.transform.childCount > 0)
            {
                scoreManager.AddScore();
            }

            fishingPause.isPaused = false;

            Destroy(gameObject);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
