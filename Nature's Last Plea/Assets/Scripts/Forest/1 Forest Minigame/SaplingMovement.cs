using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaplingMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dropSpeed = 10f;

    private bool isDropping = false;
    private float direction = 1f;

    public float boundaryLeft = -0.3f;
    public float boundaryRight = 0.3f;
    public float prefabBottom = -5f;

    public int startingPoint;
    public Transform[] points;
    private int i;

    private Vector2 originalPosition;
    //public LayerMask collisionLayer;

    private bool isGameOver = false;
    private int score = 0;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        originalPosition = transform.position;
        transform.position = points[startingPoint].position;
        boundaryLeft = -0.3f;
        boundaryRight = 0.3f;
    }

    void Update()
    {
        if (!isGameOver)
        {
            if (!isDropping)
            {
                MoveHorizontally();

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
        //transform.localPosition = Vector2.MoveTowards(transform.localPosition, leftBound.transform.localPosition, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, moveSpeed * Time.deltaTime);
    }

    void DropDown()
    {
        transform.Translate(Vector2.down * dropSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Log"))
        {
            //Debug.Log("Log");
            GameOver();
        }
        else if (other.CompareTag("Border")) // new tag for goal spots
        {
            //Debug.Log("Border");
            PlantedSafe();
        }
    }

    void PlantedSafe()
    {
        //isDropping = false;

        //_rb.constraints = RigidbodyConstraints2D.FreezeAll;
        //_rb.bodyType = RigidbodyType2D.Static;

        isGameOver = true;

        PlayerController pController = GameObject.Find("Aurora").GetComponent<PlayerController>();
        pController.DestroyInteractedObject();
        pController.inAction = false;

        Debug.Log("You Win! Minigame will be destroyed in 1 second");
        Destroy(transform.parent.gameObject, 1f);
        //score += 1;
        //Debug.Log("Plante Safe! Score: " + score);

        //transform.position = originalPosition;
    }

    void GameOver()
    {
        isGameOver = true;
        //Debug.Log("Game Over! Final Score: " + score);
    }
}
/*
 // new tag for goal spots
- Sapling Planting Manager
- - instantiate goal spots
 */