using UnityEngine;

public class CricketBallBowling : MonoBehaviour
{
    // Enum to define different types of bowling styles
    public enum BowlingType { LegSpin, OffSpin, InSwing, OutSwing }

    // Public variables to adjust in the Inspector
    public BowlingType bowlingType = BowlingType.LegSpin; // Default bowling type is LegSpin
    public float speed = 50f; // Increased speed of the ball
    public float spinForce = 20f; // Increased spin force
    public float swingForce = 20f; // Increased swing force
    public Transform pitchPoint; // Target point where the ball is aimed

    private Rigidbody rb; // Rigidbody component of the ball

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to this GameObject
        Bowl(); // Call the Bowl method to start the bowling action
    }

    void Bowl()
    {
        // Calculate the direction from the ball's current position to the pitch point and normalize it
        Vector3 direction = (pitchPoint.position - transform.position).normalized;
        // Set the initial velocity of the ball based on direction and speed
        rb.velocity = direction * speed;

        // Apply spin or swing forces based on the selected bowling type
        switch (bowlingType)
        {
            case BowlingType.LegSpin:
                rb.AddTorque(Vector3.up * spinForce, ForceMode.Impulse); // Apply spin force upwards
                break;
            case BowlingType.OffSpin:
                rb.AddTorque(Vector3.down * spinForce, ForceMode.Impulse); // Apply spin force downwards
                break;
            case BowlingType.InSwing:
                rb.AddForce(Vector3.right * swingForce, ForceMode.Impulse); // Apply swing force to the right
                break;
            case BowlingType.OutSwing:
                rb.AddForce(Vector3.left * swingForce, ForceMode.Impulse); // Apply swing force to the left
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == pitchPoint)
        {
            // Implement bounce logic here if needed
            Debug.Log("Ball pitched!"); // Output a debug message when the ball hits the pitch point
        }
    }
}
