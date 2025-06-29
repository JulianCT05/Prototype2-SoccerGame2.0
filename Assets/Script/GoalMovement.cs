using UnityEngine;

public class VerticalMover : MonoBehaviour
{
    public float speed = 2f;              // Speed of movement
    public float upperLimit = 3f;         // Upper Y boundary
    public float lowerLimit = -3f;        // Lower Y boundary

    private int direction = 1;            // 1 for up, -1 for down

    void Update()
    {
        // Calculate new position
        float newY = transform.position.y + direction * speed * Time.deltaTime;

        // Check boundaries
        if (newY > upperLimit)
        {
            newY = upperLimit;
            direction = -1; // Start moving down
        }
        else if (newY < lowerLimit)
        {
            newY = lowerLimit;
            direction = 1; // Start moving up
        }

        // Apply the new position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

}
