using UnityEngine;

public class SolidLineDetector : MonoBehaviour
{
    public DetectionLevelManager detectionManager; // Assign in Inspector
    public float penaltyAmount = 10f;              // Customize penalty per crossing

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Vehicle")) // Adjust tag if needed
        {
            Debug.Log("Vehicle crossed solid line!");
            if (detectionManager != null)
            {
                detectionManager.AddPenalty(penaltyAmount);
            }
        }
    }
}
