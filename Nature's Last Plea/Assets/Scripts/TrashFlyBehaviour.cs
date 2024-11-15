using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashFlyBehaviour : MonoBehaviour
{
    public float _velocity = 3f;

    private Rigidbody2D _rb;
    private Vector2 defaultPos;

    private SpriteRenderer _sr;
    private Color[] colors =
    {
        //Color.green, Color.blue, Color.red
        new Color(50f / 255f, 180f / 255f, 50f / 255f),
        new Color(50f / 255f, 50f / 255f, 180f / 180f),
        new Color(180f / 255f, 50f / 255f, 50f / 255f)
    };

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        defaultPos = transform.position;

        _sr = GetComponent<SpriteRenderer>();

        Color randomColor = colors[UnityEngine.Random.Range(0, colors.Length)];

        _sr.color = randomColor;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rb.velocity = Vector2.up * _velocity;
        }
        transform.Translate(Vector2.right * _velocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            transform.position = defaultPos;
            Debug.Log("Bounds Hit");
        }

        
    }
}
