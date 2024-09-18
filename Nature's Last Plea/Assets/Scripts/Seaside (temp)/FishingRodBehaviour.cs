using System.Collections;
using UnityEngine;

public class FishingRodBehaviour : MonoBehaviour
{
    public float left = -165f, right = -15f;

    public float rotationSpeed = 15f;
    public bool isPaused = false;

    public GameObject fishingHook;
    public GameObject firePoint;
    private void Start()
    {
        StartCoroutine(Rotate());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isPaused)
        {
            isPaused = true;
            Instantiate(fishingHook, new Vector2(firePoint.transform.position.z, firePoint.transform.position.y), transform.rotation);
            Debug.Log("mouse action");
        }
    }

    private IEnumerator Rotate()
    {
        while (true)
        {
            yield return RotateToAngle(right);
            yield return RotateToAngle(left);
        }
    }

    private IEnumerator RotateToAngle(float targetAngle)
    {
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);

        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            if (isPaused)
            {
                yield return null;
                continue;
            }

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }

        transform.rotation = targetRotation;
    }
}
