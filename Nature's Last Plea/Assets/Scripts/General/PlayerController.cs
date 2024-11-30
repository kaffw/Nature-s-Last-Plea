using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 PlayerInput;
    public Rigidbody2D rb;

    //public GameObject minigame, minigame2, minegame3, minigame4, minigame5, minigame6;
    public GameObject[] seasideMinigame, forestMinigame, cityMinigame;
    public GameObject sapling;

    public GameObject mainCamera;

    public bool inAction = false;

    public float moveSpeed = 1f;

    //Animation
    private Animator anim;
    private Vector2 lastDirection;
    //

    private Dictionary<string, GameObject[]> minigameMap;

    private GameObject currInteractedObject;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        mainCamera = GameObject.Find("Main Camera");

        minigameMap = new Dictionary<string, GameObject[]>
        {
            { "SeasideMinigame1", seasideMinigame },
            { "SeasideMinigame2", seasideMinigame },
            { "ForestMinigame1", forestMinigame },
            { "ForestMinigame2", forestMinigame },
            { "CityMinigame1", cityMinigame },
            { "CityMinigame2", cityMinigame }
        };

    }

    void Update()
    {
        if (!inAction)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
                rb.velocity = PlayerInput * (moveSpeed * 2);
            }
            else
            {
                PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
                rb.velocity = PlayerInput * moveSpeed;
            }

            UpdateAnim();

            //enable hitbox
            gameObject.tag = "Player";
        }
        else
        {
            //disable hitbox
            gameObject.tag = "Untagged";
        }

        //if(enableHappy) anim.SetBool("Happy", true);

    }

    void UpdateAnim() // to be polished soon
    {
        if (PlayerInput != Vector2.zero)
        {
            if (PlayerInput.y > 0) lastDirection = Vector2.up;
            else if (PlayerInput.y< 0) lastDirection = Vector2.down;
            else if (PlayerInput.x > 0) lastDirection = Vector2.right;
            else if (PlayerInput.x< 0) lastDirection = Vector2.left;

            anim.SetBool("isMoving", true);

            anim.SetBool("Running_Front", lastDirection == Vector2.down);
            anim.SetBool("Running_Back", lastDirection == Vector2.up);
            anim.SetBool("Running_Left", lastDirection == Vector2.left);
            anim.SetBool("Running_Right", lastDirection == Vector2.right);
        }
        else
        {
            anim.SetBool("isMoving", false);

            anim.SetBool("Idle_Front", lastDirection == Vector2.down);
            anim.SetBool("Idle_Back", lastDirection == Vector2.up);
            anim.SetBool("Idle_Left", lastDirection == Vector2.left);
            anim.SetBool("Idle_Right", lastDirection == Vector2.right);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (minigameMap.ContainsKey(other.tag))
        {
            if (Input.GetKeyDown(KeyCode.E) && !inAction)
            {
                rb.velocity = Vector2.zero; //disable movement upon pressing E

                GameObject[] minigameArray = minigameMap[other.tag];

                int minigameIndex = 0;

                if (other.tag == "CityMinigame2")
                {
                    minigameIndex = 1;
                }
                else if (other.tag == "SeasideMinigame2")
                {
                    minigameIndex = 1;
                }
                else if (other.tag == "ForestMinigame2")
                {
                    minigameIndex = 1;
                }

                Instantiate(minigameArray[minigameIndex], new Vector2(mainCamera.transform.position.x, mainCamera.transform.position.y), transform.rotation);
                
                inAction = true;
                //rb.velocity = 0f;
                currInteractedObject = other.gameObject;
                Debug.Log($"Entry to {other.tag}");
            }
        }
    }

    public void DestroyInteractedObject()
    {
        //clear objective before destroying
        Debug.Log("interacted objet is destroyed");



        if (currInteractedObject.CompareTag("ForestMinigame1") || currInteractedObject.CompareTag("ForestMinigame2"))
        {
            Instantiate(sapling, currInteractedObject.transform.position, currInteractedObject.transform.rotation);
        }
        Destroy(currInteractedObject);
    }
}

