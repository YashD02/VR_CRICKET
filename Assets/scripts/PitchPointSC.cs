using UnityEngine;

public class PitchPointSC : MonoBehaviour
{
    public float bounceForce = 10f;     // Adjust this value to control the strength of the bounce

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Calculate the reflection direction based on the surface normal
            Vector3 reflectionDirection = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal);

            // Apply the bounce force in the reflection direction
            rb.velocity = reflectionDirection * bounceForce;
        }
    }
}
