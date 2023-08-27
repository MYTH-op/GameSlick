using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the movement speed in the Inspector

    private bool isMoving = false;
    private Vector3 targetPosition;

    private bool isStuck = false;
    private Transform rotatingObject;
    private Vector3 hitOffset;

    void Start()
    {
        targetPosition = transform.position;
        rotatingObject = GameObject.Find("Wood").transform; // Replace "RotatingObject" with the actual name of your rotating object
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }

        if (isStuck)
        {
            transform.position = rotatingObject.TransformPoint(hitOffset);
            transform.rotation = rotatingObject.rotation;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CircleCollider2D>() != null)
        {
            isMoving = false;
            isStuck = true;
            hitOffset = rotatingObject.InverseTransformPoint(transform.position);
        }
    }

    void FixedUpdate()
    {
        if (!isMoving && !isStuck)
        {
            targetPosition = transform.position + Vector3.up; // Move one unit in the positive Y-axis
            isMoving = true;
        }
    }
}
