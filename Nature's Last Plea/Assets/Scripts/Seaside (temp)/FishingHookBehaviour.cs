using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingHookBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public float reelSpeed = 3f;

    public bool isReturning = false;

    public FishingRodBehaviour fishingPause;
    public ReelingThemInScoreManager scoreManager;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fishingPause = GameObject.Find("Fishing Rod").GetComponent<FishingRodBehaviour>();
        scoreManager = GameObject.Find("Reeling Them In Score").GetComponent<ReelingThemInScoreManager>();
    }
    void Update()
    {
        if(!isReturning) rb.velocity = transform.right * reelSpeed;
        else rb.velocity = -transform.right * reelSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            Debug.Log("Border Reached");
            isReturning = true;
        }

        if (other.CompareTag("Trash"))
        {
            other.transform.SetParent(gameObject.transform);
            isReturning = true;
        }

        if (other.CompareTag("Player"))
        {
            if (gameObject.transform.childCount > 0)
            {
                scoreManager.AddScore();
            }

            fishingPause.isPaused = false;

            Destroy(gameObject);
        }
    }
}
