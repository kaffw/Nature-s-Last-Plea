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
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        mainCamera = GameObject.Find("Main Camera");
    }
    void Update()
    {
        if (!inAction)
        {
            PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            rb.velocity = PlayerInput;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Minigame"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(minigame, new Vector2(mainCamera.transform.position.x, mainCamera.transform.position.y), transform.rotation);
                inAction = true;
                Debug.Log("Entry to minigame");
            }
        }
    }
}