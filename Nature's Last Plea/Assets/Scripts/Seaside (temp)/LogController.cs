using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogController : MonoBehaviour
{
    public float speed;
    public bool directionRight;
    public GameObject objectManager;

    public float x, y;

    void Start()
    {
        objectManager = GameObject.Find("Obstacles Manager");

        directionRight = (transform.position.x <= objectManager.transform.position.x) ? true : false;
        speed = 1f;

        x = transform.position.x;
        transform.position = new Vector2(x, objectManager.transform.position.y + (Random.Range(-3, 1f)));
    }

    void Update()
    {
        if (directionRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position -= Vector3.right * speed * Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            transform.position = new Vector2(x, objectManager.transform.position.y + (Random.Range(-3, 1f)));
            Debug.Log(gameObject.name + "transported");
        }
    }
}
