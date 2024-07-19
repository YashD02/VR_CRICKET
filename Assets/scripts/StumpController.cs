using UnityEngine;

public class StumpController : MonoBehaviour
{
    public float fallForce = 10f;      // Force to apply to make the stump fall
    public float fallTorque = 5f;      // Torque applied to simulate spinning or falling rotation

    private Rigidbody rb;
    private bool isHit = false;         // Flag to track if the stump has been hit

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isHit && collision.gameObject.CompareTag("Ball"))
        {
            isHit = true;
            FallStump();
        }
    }

    void FallStump()
    {
        // Enable Rigidbody to allow physics to affect the stump
        rb.isKinematic = false;

        // Add force to make the stump fall backward
        rb.AddForce(Vector3.back * fallForce, ForceMode.Impulse);

        // Add torque to simulate spinning or falling rotation
        //rb.AddTorque(Vector3.up * fallTorque, ForceMode.Impulse);

        // Example: You can disable collider to prevent further interactions
        GetComponent<Collider>().enabled = false;

        // Optional: You can also play a falling animation or particle effect here
    }
}
