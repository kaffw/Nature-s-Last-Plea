using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaplingMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed for horizontal movement
    public float dropSpeed = 10f; // Speed for the drop
    private bool isDropping = false; // To check if the character is dropping
    private float direction = 1f; // Initial movement direction (right)
    public float boundaryLeft = -7f; // Left boundary of the prefab
    public float boundaryRight = 7f; // Right boundary of the prefab
    public float prefabBottom = -5f; // Bottom boundary of the prefab (adjust this based on your scene)

    private Vector2 originalPosition; // To store the original position
    public LayerMask collisionLayer; // Layer to detect obstacles during drop
    private bool isGameOver = false;
    private int score = 0; // Score for successful planting

    void Start()
    {
        // Store the sapling's starting position
        originalPosition = transform.position;
    }

    void Update()
    {
        // If the game is not over
        if (!isGameOver)
        {
            // If the player is not dropping, move left and right
            if (!isDropping)
            {
                MoveHorizontally();

                // Check for left mouse button click to initiate the drop
                if (Input.GetMouseButtonDown(0))
                {
                    isDropping = true;
                }
            }
            else
            {
                DropDown();
            }
        }
    }

    void MoveHorizontally()
    {
        // Move the character left and right
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);

        // Check if the character has reached the prefab boundaries and change direction
        if (transform.position.x >= boundaryRight)
        {
            direction = -1f; // Move left
        }
        else if (transform.position.x <= boundaryLeft)
        {
            direction = 1f; // Move right
        }
    }

    void DropDown()
    {
        // Move the character downwards when dropping
        transform.Translate(Vector2.down * dropSpeed * Time.deltaTime);

        // Check for collisions with other objects

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, dropSpeed * Time.deltaTime, collisionLayer);

        // if (hit.collider != null)
        // {
        //     // If hit an object, trigger game over
        //     GameOver();
        // }
        // else if (transform.position.y <= prefabBottom)
        // {
        //     // If it reaches the bottom of the prefab without hitting anything
        //     PlantedSafe();
        // }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Log"))
        {
            Debug.Log("Log");
            GameOver();
        }
        else if (other.gameObject.CompareTag("Border"))
        {
            Debug.Log("Border");
            PlantedSafe();
        }
    }

    void PlantedSafe()
    {
        isDropping = false; // Stop the drop
        score += 1; // Increment score
        Debug.Log("Planted Safe! Score: " + score);

        // Reset sapling position to the original position for the next round
        transform.position = originalPosition;
    }

    void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over! Final Score: " + score);

        // Add any additional game-over logic here (e.g., stopping movement, showing UI, etc.)
    }
}



