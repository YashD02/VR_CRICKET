using UnityEngine;

public class BallBounceHighlight : MonoBehaviour
{
    public GameObject highlightPrefab; // Prefab to use for highlighting the bounce point
    public float highlightDuration = 2.0f; // Duration to show the highlight

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the plane (or ground)
        if (collision.gameObject.CompareTag("Pitch"))
        {
            // Get the contact point of the collision
            ContactPoint contact = collision.contacts[0];
            Vector3 contactPoint = contact.point;

            // Instantiate the highlight at the contact point and rotate it to lie flat
            GameObject highlight = Instantiate(highlightPrefab, contactPoint, Quaternion.Euler(90, 0, 0));

            // Destroy the highlight after the specified duration
            Destroy(highlight, highlightDuration);
        }
    }
}
