using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 30f; // Initial rotation speed, editable in the Inspector

    void Update()
    {
        // Rotate the object around its up axis with the specified speed
        transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
    }

    // Function to update the rotation speed from the Inspector
    public void UpdateRotationSpeed(float newSpeed)
    {
        rotationSpeed = newSpeed;
    }
}
