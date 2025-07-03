using UnityEngine;

public class SolidLineDetector : MonoBehaviour
{
    public DetectionLevelManager detectionManager; 
    public float penaltyAmount = 10f;              
    public float cooldownTime = 5f;                

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
