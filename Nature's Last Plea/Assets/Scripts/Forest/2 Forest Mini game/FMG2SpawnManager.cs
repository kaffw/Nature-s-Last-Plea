using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMG2SpawnManager : MonoBehaviour
{
    // Prefabs for the items to spawn
    public GameObject seedPrefab, waterPrefab, sunlightPrefab, trashPrefab;
    public float spawnInterval = 2f; // Time between spawns
    public float spawnRangeX = 9f; // Horizontal spawn range (adjusted for your 18x10 rectangle)
    public float spawnY = 5f; // Top Y-position for spawning items
    public float bottomY = -5f; // Bottom Y-position of the rectangle

    private float timer; // Timer to track spawn intervals
    private bool isGameActive; // Flag to track if the game is active

    // Parent transform for relative positioning
    private Transform parentTransform;

    public GameObject tutorial;

    void Start()
    {
        isGameActive = true;
        parentTransform = transform; // Use this object's transform as the parent
        Debug.Log("Game Started");
    }

    void Update()
    {
        if(tutorial == null)
        {
            if (!isGameActive) return;

            timer += Time.deltaTime;

            if (timer >= spawnInterval)
            {
                SpawnItem();
                timer = 0;  // Reset the timer
            }
        }
    }

    public void StartGame()
    {
        isGameActive = true; // Activate the game
    }

    public void EndGame()
    {
        //isGameActive = false; // Deactivate the game
        isGameActive = false;
        StartCoroutine(WinMiniGame());
    }

    void SpawnItem()
    {
        // List to keep track of spawn positions to avoid overlap
        List<Vector3> spawnPositions = new List<Vector3>();

        for (int i = 0; i < 6; i++)
        {
            // Randomly pick an item to spawn
            GameObject itemToSpawn;
            int random = Random.Range(0, 4); // Generates a random number between 0 and 3

            switch (random)
            {
                case 0:
                    itemToSpawn = seedPrefab;
                    break;
                case 1:
                    itemToSpawn = waterPrefab;
                    break;
                case 2:
                    itemToSpawn = sunlightPrefab;
                    break;
                case 3:
                    itemToSpawn = trashPrefab;
                    break;
                default:
                    itemToSpawn = null;
                    break;
            }

            if (itemToSpawn != null)
            {
                Vector3 spawnPosition;

                // Ensure the position doesn't overlap with previous items
                int attempts = 0;
                do
                {
                    // Calculate a position relative to the parent
                    spawnPosition = parentTransform.position +
                                    new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnY, 0);
                    attempts++;
                }
                while (IsPositionTooClose(spawnPosition, spawnPositions) && attempts < 10);

                // Add the valid position to the list and spawn the item
                spawnPositions.Add(spawnPosition);
                Instantiate(itemToSpawn, spawnPosition, Quaternion.identity);
            }
        }
    }

    // Helper method to check if a position is too close to existing ones
    bool IsPositionTooClose(Vector3 newPosition, List<Vector3> existingPositions, float minDistance = 1.5f)
    {
        foreach (Vector3 position in existingPositions)
        {
            if (Vector3.Distance(newPosition, position) < minDistance)
            {
                return true;
            }
        }
        return false;
    }

    private IEnumerator WinMiniGame()
    {
        PlayerController pController = GameObject.Find("Aurora").GetComponent<PlayerController>();
        pController.DestroyInteractedObject();
        pController.inAction = false;

        Debug.Log("You Win! Minigame will be destroyed in 1 second");
        Destroy(transform.parent.gameObject, 0.1f);

        //Fade Handler
        VirtualCameraManager.inMinigame = false;
        VirtualCameraManager fade = FindObjectOfType<VirtualCameraManager>();
        fade.Fades();

        yield return null;
    }

    public IEnumerator DefeatMiniGame()
    {
        PlayerController pController = GameObject.Find("Aurora").GetComponent<PlayerController>();
        pController.inAction = false;

        Debug.Log("You Win! Minigame will be destroyed in 1 second");
        Destroy(transform.parent.gameObject, 0.1f);

        //Fade Handler
        VirtualCameraManager.inMinigame = false;
        VirtualCameraManager fade = FindObjectOfType<VirtualCameraManager>();
        fade.Fades();

        yield return null;
    }
}
