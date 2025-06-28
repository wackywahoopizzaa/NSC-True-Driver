using UnityEngine;

public class CollisionPenalty : MonoBehaviour
{
    public DetectionLevelManager detectionManager; // Assign in Inspector
    public float collisionPenalty = 15f;           // Amount to increase detection bar
    public float cooldownTime = 3f;                // Seconds to wait before next penalty

    private bool canBePenalized = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (!canBePenalized) return;

        if (collision.gameObject.CompareTag("Traffic"))
        {
            Debug.Log("Player collided with a traffic vehicle!");

            if (detectionManager != null)
            {
                detectionManager.AddPenalty(collisionPenalty);
            }

            canBePenalized = false;
            Invoke(nameof(ResetCooldown), cooldownTime);
        }
    }

    private void ResetCooldown()
    {
        canBePenalized = true;
    }
}
