using UnityEngine;

public class CollisionPenalty : MonoBehaviour
{
    public DetectionLevelManager detectionManager; 
    public float collisionPenalty = 15f;           
    public float cooldownTime = 3f;                

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
