using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotMovement : MonoBehaviour
{
    public float minX = -8f;
    public float maxX = 8f;
    public float followSpeed = 10f;

    private Transform parentTransform;

    void Start()
    {
        parentTransform = transform.parent;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MovePot(-1);
        }

        if (Input.GetMouseButton(1))
        {
            MovePot(1);
        }
    }

    void MovePot(int direction)
    {
        float desiredX = transform.position.x + direction * followSpeed * Time.deltaTime;

        float minXPosition = parentTransform.position.x + minX;
        float maxXPosition = parentTransform.position.x + maxX;

        float clampedX = Mathf.Clamp(desiredX, minXPosition, maxXPosition);

        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
