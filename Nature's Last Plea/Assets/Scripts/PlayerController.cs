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

    //Animation
    private Animator anim;
    private Vector2 lastDirection;
    //
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        mainCamera = GameObject.Find("Main Camera");
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

            if (PlayerInput != Vector2.zero)
            {
                if (PlayerInput.y > 0) lastDirection = Vector2.up;
                else if (PlayerInput.y < 0) lastDirection = Vector2.down;
                else if (PlayerInput.x > 0) lastDirection = Vector2.right;
                else if (PlayerInput.x < 0) lastDirection = Vector2.left;

                anim.SetBool("isMoving", false);
                anim.SetBool("Idle_Front", false);
                anim.SetBool("Idle_Back", false);
                anim.SetBool("Idle_Left", false);
                anim.SetBool("Idle_Right", false);

                if (lastDirection == Vector2.up) anim.SetBool("Idle_Back", true);
                else if (lastDirection == Vector2.down) anim.SetBool("Idle_Front", true);
                else if (lastDirection == Vector2.left) anim.SetBool("Idle_Left", true);
                else if (lastDirection == Vector2.right) anim.SetBool("Idle_Right", true);
            }
            //else
            //{
            //    anim.SetBool("isMoving", false);
            //    anim.SetBool("Idle_Front", false);
            //    anim.SetBool("Idle_Back", false);
            //    anim.SetBool("Idle_Left", false);
            //    anim.SetBool("Idle_Right", false);

            //    if (lastDirection == Vector2.up) anim.SetBool("Idle_Back", true);
            //    else if (lastDirection == Vector2.down) anim.SetBool("Idle_Front", true);
            //    else if (lastDirection == Vector2.left) anim.SetBool("Idle_Left", true);
            //    else if (lastDirection == Vector2.right) anim.SetBool("Idle_Right", true);
            //}


            //if (PlayerInput != Vector2.zero)
            //{
            //    lastDirection = PlayerInput;
            //    //animator.SetBool("isMoving", true);
            //    //animator.SetFloat("MoveX", PlayerInput.x);
            //    //animator.SetFloat("MoveY", PlayerInput.y);
            //}
            //else
            //{
            //    //animator.SetBool("isMoving", false);

            //    // Set idle animation based on last direction
            //    //anim.SetFloat("IdleX", lastDirection.x);
            //    //anim.SetFloat("IdleY", lastDirection.y);
            //}

            //enable hitbox
            gameObject.tag = "Player";
        }
        else
        {
            //disable hitbox
            gameObject.tag = "Untagged";
        }


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

/*
if (PlayerInput.y < 0) anim.SetBool("Idle_Front", true); else anim.SetBool("Idle_Front", false);
if (PlayerInput.x < 0) anim.SetBool("Idle_Left", true); else anim.SetBool("Idle_Left", false);
if (PlayerInput.y > 0) anim.SetBool("Idle_Back", true); else anim.SetBool("Idle_Back", false);
if (PlayerInput.x > 0) anim.SetBool("Idle_Right", true); else anim.SetBool("Idle_Right", false);
 */