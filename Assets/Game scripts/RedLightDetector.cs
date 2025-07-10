using UnityEngine;

public class RedLightDetector : MonoBehaviour
{
    public IntersectionTrafficController intersectionController; // Assigned in Inspector
    public int trafficGroupIndex; // Which group this detector belongs to
    public DetectionLevelManager detectionManager;
    public Transform forwardDirection;
    public string vehicleTag = "Player";

    public float directionThreshold = 0.5f;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(vehicleTag)) return;
        if (intersectionController == null) return;

        Rigidbody vehicleRb = other.attachedRigidbody;
        if (vehicleRb == null) return;

        // Make sure vehicle is going in the intended direction
        Vector3 vehicleDir = vehicleRb.velocity.normalized;
        Vector3 allowedDir = forwardDirection.forward.normalized;
        float dot = Vector3.Dot(vehicleDir, allowedDir);

        if (dot < directionThreshold)
        {
            Debug.Log("Vehicle not heading into intersection — no penalty.");
            return;
        }

        // Only allow passage if THIS group has the green light
        if (!intersectionController.IsGroupAllowedToGo(trafficGroupIndex))
        {
            Debug.Log("Red Light Violation! Group: " + trafficGroupIndex);

            if (detectionManager != null)
            {
                detectionManager.AddPenalty(20f);
            }
        }
    }
}
