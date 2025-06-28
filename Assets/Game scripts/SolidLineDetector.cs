using UnityEngine;

public class SolidLineDetector : MonoBehaviour
{
    public DetectionLevelManager detectionManager; // Assign in Inspector
    public float penaltyAmount = 10f;              // Penalty per crossing
    public float cooldownTime = 5f;                // Time in seconds between penalties

    private bool canTrigger = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!canTrigger) return;

        if (other.CompareTag("Player") || other.CompareTag("Vehicle"))
        {
            Debug.Log("Vehicle crossed solid line!");

            if (detectionManager != null)
            {
                detectionManager.AddPenalty(penaltyAmount);
            }

            canTrigger = false;
            Invoke(nameof(ResetTrigger), cooldownTime);
        }
    }

    private void ResetTrigger()
    {
        canTrigger = true;
    }
}
