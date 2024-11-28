using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // For TextMeshPro

public class ItemCollector : MonoBehaviour
{
    private int collectionStage = 0;
    public bool gameOver = false;
    public TextMeshProUGUI statusText;

    void Start()
    {
        UpdateStatusText("Awaiting Seed");
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
            UpdateStatusText("Seed collected! Next: Water");
            Debug.Log("Seed");
        }
        else if (other.CompareTag("Water") && collectionStage == 1)
        {
            collectionStage++;
            UpdateStatusText("Water collected! Next: Sunlight");
            Debug.Log("Water");
        }
        else if (other.CompareTag("Sunlight") && collectionStage == 2)
        {
            collectionStage++;
            UpdateStatusText("Sunlight collected! Goal Complete!");
            Debug.Log("Sunlight");
            CompleteGame(); // Call method to handle game completion
        }
        else if (other.CompareTag("Trash"))
        {
            UpdateStatusText("Game Over! You hit trash.");
            Debug.Log("Trash");
            //EndGame(); // Call method to handle game over
        }
        else if (collectionStage >= 0 && collectionStage <= 2) // Ensure correct sequence
        {
            UpdateStatusText("Wrong item collected! Expected: " + GetExpectedItem());
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

    void UpdateStatusText(string message)
    {
        if (statusText != null)
        {
            statusText.text = message; // Update the UI text
        }
    }

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