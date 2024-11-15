using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] trashPrefab;

    //public float spawnXOffset = 1.5f; // Controls the range on the X axis
    //public float spawnYOffset = 3f; // Controls the range on the Y axis
    public int numLeavesToSpawn = 20; // Total number of leaves to spawn
    
    private int rand;
    public static int totalLeaves;
    private bool oneInstance = false;

    void Start()
    {
        for (int i = 0; i < numLeavesToSpawn; i++)
        {
            rand = Random.Range(0, trashPrefab.Length);

            Vector3 spawnPosition = new Vector3 // original scale over parent's scale
            (
                Random.Range(-8, 9), //23
                Random.Range(-3, 4), //11
                0
            );

            Quaternion spawnRotation = Quaternion.Euler
            (
                0,
                0,
                Random.Range(0, 360)
            );

            Instantiate(trashPrefab[rand], transform.position + spawnPosition, spawnRotation);
        }

        totalLeaves = numLeavesToSpawn;
    }

    void Update()
    {
        if (totalLeaves <= 0 && !oneInstance)
        {
            oneInstance = true;

            Debug.Log("You Win! Minigame will be destroyed in 1 second");

            Destroy(gameObject, 1f);
        }
    }
}

//void Start()
//{
//    // Find all capsules in the scene
//    GameObject[] capsules = GameObject.FindGameObjectsWithTag("Capsule"); // Assuming you tagged the capsules as "Capsule"

//    // Check if we have at least 1 capsule to spawn leaves around
//    if (capsules.Length == 0) return;

//    // Spawn a set number of leaves
//    for (int i = 0; i < numLeavesToSpawn; i++)
//    {
//        // Choose a random capsule
//        GameObject chosenCapsule = capsules[Random.Range(0, capsules.Length)];

//        // Generate a random position near the chosen capsule
//        Vector3 spawnPosition = chosenCapsule.transform.position + new Vector3(
//            Random.Range(-spawnXOffset, spawnXOffset), // Randomize on X axis
//            Random.Range(-spawnYOffset, spawnYOffset), // Randomize on Y axis
//            0 // Keep Z axis constant
//        );

//        // Instantiate the leaves at the calculated position
//        rand = Random.Range(0, trashPrefab.Length - 1);
//        Instantiate(trashPrefab[rand], spawnPosition, Quaternion.identity);
//    }
//}