using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public float initialSpeed = 10f;   // Initial speed of the ball
    public float spinSpeed = 100f;     // Speed of spin
    public Vector3 spinAxis = Vector3.up;   // Axis of spin (usually up for cricket)

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        // Reset ball position and rotation
        rb.position = transform.position;
        rb.rotation = transform.rotation;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Calculate initial velocity
        Vector3 initialVelocity = transform.forward * initialSpeed;

        // Apply spin
        rb.angularVelocity = spinAxis * spinSpeed;

        // Apply initial velocity
        rb.velocity = initialVelocity;
    }
}
