using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 PlayerInput;
    public Rigidbody2D rb;

    public GameObject minigame;

    public GameObject mainCamera;

    public bool inAction = false;

    public float moveSpeed = 1f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        mainCamera = GameObject.Find("Main Camera");
    }
    void Update()
    {
        //if (!inAction)
        //{
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
            
        //}

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Minigame"))
        {
            if (Input.GetKeyDown(KeyCode.E) && !inAction)
            {
                Instantiate(minigame, new Vector2(mainCamera.transform.position.x, mainCamera.transform.position.y), transform.rotation);
                inAction = true;
                Debug.Log("Entry to minigame");
            }
        }
    }
}

/*
 * 10/20/24
Changes: JM
Added circle collider 2d in character inspector components with trigger... place above capsule collider 2d

before:
    if (Input.GetKeyDown(KeyCode.E))

after:
    if (Input.GetKeyDown(KeyCode.E) && !inAction)

 */