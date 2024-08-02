using System.Collections;
using UnityEngine;

public class BailResetOnChange : MonoBehaviour
{
    public float resetTime = 4.0f; // Time in seconds before the bails reset

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Rigidbody bailRigidbody;

    void Start()
    {
        // Store the original position and rotation of the bail
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        bailRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the bail's position has changed significantly
        if (Vector3.Distance(transform.position, originalPosition) > 1f)
        {
            // Start the reset coroutine if the bail has moved
            StartCoroutine(ResetBailAfterTime());
        }
    }

    private IEnumerator ResetBailAfterTime()
    {
        // Wait for the specified reset time
        yield return new WaitForSeconds(resetTime);

        // Reset the bail to its original position and rotation
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        bailRigidbody.velocity = Vector3.zero; // Stop any movement
        bailRigidbody.angularVelocity = Vector3.zero; // Stop any rotation
    }
}
