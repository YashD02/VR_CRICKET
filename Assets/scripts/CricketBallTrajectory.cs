using UnityEngine;

public class CricketBallTrajectory : MonoBehaviour
{
    public enum BowlingType { LegSpin, OffSpin, InSwing, OutSwing }

    public BowlingType bowlingType = BowlingType.LegSpin;

    public float speed = 25f;
    public float spinForce = 5f;
    public float swingForce = 5f;
    public Transform pitchPoint;
    public float maxDeviationAngle = 4f; // Maximum angle in degrees for deviation

    private Rigidbody rb;
    private Vector3 initialPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position; // Store the initial position of the ball
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RespawnAndLaunchBall();
        }
    }

    void RespawnAndLaunchBall()
    {
        // Reset the ball to the initial position
        transform.position = initialPosition;

        // Reset Rigidbody properties
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Calculate the base direction towards the pitchPoint
        Vector3 direction = (pitchPoint.position - transform.position).normalized;

        // Calculate the maximum deviation angle in radians
        float maxDeviationAngleRad = maxDeviationAngle * Mathf.Deg2Rad;

        // Randomize within a cone around the original direction
        Vector3 randomDeviation = Random.insideUnitSphere.normalized * Mathf.Tan(maxDeviationAngleRad);
        direction = Quaternion.LookRotation(direction + randomDeviation) * Vector3.forward;

        // Set the velocity with the adjusted direction and speed
        rb.velocity = direction * speed * 2;

        // Apply additional forces based on the bowling type
        switch (bowlingType)
        {
            case BowlingType.LegSpin:
                rb.AddTorque(Vector3.up * spinForce, ForceMode.Impulse);
                break;
            case BowlingType.OffSpin:
                rb.AddTorque(Vector3.down * spinForce, ForceMode.Impulse);
                break;
            case BowlingType.InSwing:
                rb.AddForce(Vector3.right * swingForce, ForceMode.Impulse);
                break;
            case BowlingType.OutSwing:
                rb.AddForce(Vector3.left * swingForce, ForceMode.Impulse);
                break;
        }
    }
}
