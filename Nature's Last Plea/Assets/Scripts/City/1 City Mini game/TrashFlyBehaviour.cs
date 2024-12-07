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

    private string[] colorCollection;
    private string colorSet;

    private bool isWin = false;

    public AudioClip jumpSFX; // Jump sound effect
    public AudioClip fallSFX; // Fall sound effect
    public AudioClip winSFX; // win sound effect
    private AudioSource audioSource;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>(); // Get AudioSource component

        defaultPos = transform.position;

        colorCollection = new string[] { "Green", "Blue", "Red" };

        int rand = UnityEngine.Random.Range(0, colors.Length);

        Color randomColor = colors[rand];
        colorSet = colorCollection[rand];

        Debug.Log(colorSet);

        _sr.color = randomColor;
    }

    void Update()
    {
        if (!isWin)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _rb.velocity = Vector2.up * _velocity;

                // Play jump sound effect
                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(jumpSFX);
                }
            }
            transform.Translate(Vector2.right * _velocity * Time.deltaTime);
        }
        else
        {
            _rb.bodyType = RigidbodyType2D.Static;

            PlayerController pController = GameObject.Find("Aurora").GetComponent<PlayerController>();
            pController.DestroyInteractedObject();
            pController.inAction = false;

            Debug.Log("You Win! Minigame will be destroyed in 1 second");
            Destroy(transform.parent.gameObject, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            transform.position = defaultPos;

            // Play fall sound effect
            audioSource.PlayOneShot(fallSFX);

            Debug.Log("Bounds Hit");
        }

        if (other.CompareTag("Trash"))
        {
            TrashCanColorSetter colorSetter = other.gameObject.GetComponent<TrashCanColorSetter>();
            string hitColor = colorSetter.GOcolor;

            if (hitColor == colorSet)
            {
                Debug.Log("Correct Trash Can");
                // Play fall sound effect
                audioSource.PlayOneShot(winSFX);
                //Enable move after mini game / destroyer of interacted object //copy to every win condition of minigames
                isWin = true;
            }
            else
            {
                Debug.Log("Incorrect Trash Can");
            }
        }
    }
}
