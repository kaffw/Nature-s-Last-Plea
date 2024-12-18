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

    private bool isGameOver = false;

    private Rigidbody2D _rb;

    // Sound effect references
    //public AudioClip successSound; // Sound when planted in water area
    //public AudioClip failSound;    // Sound when dropped to the ground
    //private AudioSource audioSource;
    
    AudioManager am;

    public GameObject tutorial;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //audioSource = GetComponent<AudioSource>(); // Ensure there's an AudioSource component
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        originalPosition = transform.position;
        transform.position = points[startingPoint].position;
        boundaryLeft = -0.3f;
        boundaryRight = 0.3f;
    }

    void Update()
    {
        if(tutorial == null)
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
        if (other.CompareTag("Log")) // Fail condition
        {
            //PlaySound(failSound);
            am.PlaySFX(4);
            GameOver();
        }
        else if (other.CompareTag("Border")) // Success condition
        {
            //PlaySound(successSound);
            am.PlaySFX(5);
            PlantedSafe();
        }
    }

    void PlantedSafe()
    {
        isGameOver = true;

        PlayerController pController = GameObject.Find("Aurora").GetComponent<PlayerController>();
        pController.DestroyInteractedObject();
        pController.inAction = false;

        //Fade Handler
        VirtualCameraManager.inMinigame = false;
        VirtualCameraManager fade = FindObjectOfType<VirtualCameraManager>();
        fade.Fades();

        Debug.Log("You Win! Minigame will be destroyed in 1 second");
        Destroy(transform.parent.gameObject, 0.1f);
    }

    void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over!");
        PlayerController pc = GameObject.Find("Aurora").GetComponent<PlayerController>();
        pc.inAction = false;

        //Fade Handler
        VirtualCameraManager.inMinigame = false;
        VirtualCameraManager fade = FindObjectOfType<VirtualCameraManager>();
        fade.Fades();

        Destroy(transform.parent.gameObject);
    }

    // Play the appropriate sound
    /*void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }*/
}
