using UnityEngine;

public class BallPitcher : MonoBehaviour
{
    public GameObject ballPrefab;       // Prefab of the ball to pitch
    public Transform pitchStartPosition;   // Start position of the pitch
    public float pitchSpeed = 10f;      // Speed of the pitch
    public float pitchHeight = 2f;      // Height of the pitch trajectory
    public float pitchDistance = 10f;   // Distance to pitch the ball

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PitchBall();
        }
    }

    void PitchBall()
    {
        // Instantiate a new ball prefab at the pitch start position
        GameObject ball = Instantiate(ballPrefab, pitchStartPosition.position, Quaternion.identity);

        // Calculate pitch direction (towards the end point)
        Vector3 pitchDirection = (pitchStartPosition.forward + pitchStartPosition.up * pitchHeight).normalized;

        // Apply force to the ball in the calculated direction
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.velocity = pitchDirection * pitchSpeed;

        // Destroy the ball after a certain time (adjust as needed)
        Destroy(ball, 5f);
    }
}

