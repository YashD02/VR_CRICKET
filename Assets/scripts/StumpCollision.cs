using UnityEngine;
using System.Collections;

public class StumpCollision : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    public float resetDelay = 6f; // Time after which the stumps reset
    public float forceMultiplier = 2.0f; // Multiplier to increase falling speed
    public float angularDrag = 0.05f; // Reduce angular drag for more realistic falling

    void Start()
    {
        // Store the initial position and rotation of the stump
        initialPosition = transform.position;
        initialRotation = transform.rotation;

        // Set initial angular drag for more realistic falling
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.angularDrag = angularDrag;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Logic for stump falling
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(collision.relativeVelocity * forceMultiplier, ForceMode.Impulse);

            // Start coroutine to reset the stump after a delay
            StartCoroutine(ResetStumpAfterDelay());
        }
    }

    IEnumerator ResetStumpAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(resetDelay);

        // Reset the position and rotation of the stump
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        // Make the Rigidbody kinematic again to stop further physics interactions
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
}
