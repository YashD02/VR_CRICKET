using UnityEngine;

public class StumpFalling : MonoBehaviour
{
    public float fallForce = 1000f;      // Horizontal force to apply to make the stump fall
    public float fallTorque = 100f;      // Torque applied to simulate spinning or falling rotation

    private Rigidbody rb;
    private bool isHit = false;          // Flag to track if the stump has been hit

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;          // Ensure Rigidbody starts as kinematic
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isHit && collision.gameObject.CompareTag("Ball"))
        {
            isHit = true;
            FallStump(collision);
        }
    }

    void FallStump(Collision collision)
    {
        // Enable Rigidbody to allow physics to affect the stump
        rb.isKinematic = false;  // This line turns on gravity and other physics effects

        // Calculate horizontal force direction based on the collision point
        Vector3 forceDirection = new Vector3(transform.position.x - collision.transform.position.x, 0, transform.position.z - collision.transform.position.z);
        forceDirection.Normalize();

        // Add force to make the stump fall sideways
        rb.AddForce(forceDirection * fallForce, ForceMode.Impulse);

        // Add torque to simulate spinning or falling rotation
        rb.AddTorque(Random.insideUnitSphere * fallTorque, ForceMode.Impulse);

        // Disable collider to prevent further interactions
        GetComponent<Collider>().enabled = false;
    }
}
