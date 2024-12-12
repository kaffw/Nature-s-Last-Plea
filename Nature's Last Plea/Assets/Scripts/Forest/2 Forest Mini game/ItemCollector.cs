using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // For TextMeshPro

public class ItemCollector : MonoBehaviour
{
    private int collectionStage = 0;
    public bool gameOver = false;
    public GameObject seedIndicator;
    public GameObject dropletIndicator;
    public GameObject sunlightIndicator;
    
    // public TextMeshProUGUI statusText;

    // Audio Clips for Sound Effects
    //public AudioClip sfxA; // Sound effect for Seed, Water, Sunlight //1
    //public AudioClip sfxB; // Sound effect for Trash //2
    //private AudioSource audioSource;

    AudioManager am;

    void Start()
    {
        // Get the AudioSource component
        /*audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component missing from this game object.");
        }*/

        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        // UpdateStatusText("Awaiting Seed");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameOver)
        {
            return;
        }

        if (!other.CompareTag("Trash") && !other.CompareTag("Seed") &&
            !other.CompareTag("Water") && !other.CompareTag("Sunlight"))
        {
            return; // Ignore other colliders
        }

        if (other.CompareTag("Seed") && collectionStage == 0)
        {
            collectionStage++;
            //PlaySound(sfxA);
            am.PlaySFX(1);
            // UpdateStatusText("Seed collected! Next: Water");
            seedIndicator.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            Debug.Log("Seed");
        }
        else if (other.CompareTag("Water") && collectionStage == 1)
        {
            collectionStage++;
            //PlaySound(sfxA);
            am.PlaySFX(1);
            // UpdateStatusText("Water collected! Next: Sunlight");
            dropletIndicator.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            Debug.Log("Water");
        }
        else if (other.CompareTag("Sunlight") && collectionStage == 2)
        {
            collectionStage++;
            //PlaySound(sfxA);
            am.PlaySFX(1);
            // UpdateStatusText("Sunlight collected! Goal Complete!");
            sunlightIndicator.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            Debug.Log("Sunlight");
            CompleteGame(); // Call method to handle game completion
        }
        else if (other.CompareTag("Trash"))
        {
            //PlaySound(sfxB);
            am.PlaySFX(2);
            // UpdateStatusText("Game Over! You hit trash.");
            Debug.Log("Trash");
            //EndGame(); // Call method to handle game over
        }
        else if (collectionStage >= 0 && collectionStage <= 2) // Ensure correct sequence
        {
            //PlaySound(sfxB);
            am.PlaySFX(2);
            // UpdateStatusText("Wrong item collected! Expected: " + GetExpectedItem());
            Debug.Log("Wrong item collected");
            //EndGame(); // Call method to handle wrong collection
        }

        Destroy(other.gameObject); // Destroy the collected item
    }

    void CompleteGame()
    {
        gameOver = true; // Set the game over flag
        Debug.Log("Game Completed Successfully!");
        FMG2SpawnManager SM = GameObject.Find("FMG2 Spawn Manager").GetComponent<FMG2SpawnManager>();
        SM.EndGame(); // Stop spawning new items
    }

    void EndGame()
    {
        gameOver = true; // Set the game over flag
        FMG2SpawnManager SM = GameObject.Find("FMG2 Spawn Manager").GetComponent<FMG2SpawnManager>();
        SM.EndGame(); // Stop spawning new items
    }

    /*
    void UpdateStatusText(string message)
    {
        if (statusText != null)
        {
            statusText.text = message; // Update the UI text
        }
    }
    */
    /*void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip); // Play the provided sound effect
        }
    }*/

    // Helper method to return the expected item message
    string GetExpectedItem()
    {
        switch (collectionStage)
        {
            case 0: return "Seed";
            case 1: return "Water";
            case 2: return "Sunlight";
            default: return "Unknown item";
        }
    }
}
