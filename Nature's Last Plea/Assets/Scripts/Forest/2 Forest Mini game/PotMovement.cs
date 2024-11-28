using UnityEngine;

public class PotMovement : MonoBehaviour
{
    public float minX = -8f; // Left boundary of the green rectangle
    public float maxX = 8f;  // Right boundary of the green rectangle
    public float followSpeed = 10f; // Speed at which the pot follows the cursor

    void Update()
    {

        // Check if the left mouse button is being held down
        if (Input.GetMouseButton(0))
        {
            // Get the mouse position in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Set the Z coordinate to match the pot's position
            mousePosition.z = transform.position.z;

            // Clamp the X position of the mouse to keep it within the boundaries
            float clampedX = Mathf.Clamp(mousePosition.x, minX, maxX);

            // Smoothly interpolate the pot's position toward the mouse position
            float targetX = Mathf.Lerp(transform.position.x, clampedX, Time.deltaTime * followSpeed);

            // Update the pot's position (only on the X axis)
            transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
        }
    }
}