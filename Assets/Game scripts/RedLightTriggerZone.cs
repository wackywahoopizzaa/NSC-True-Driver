using UnityEngine;

public class RedLightTriggerZone : MonoBehaviour
{
    public DetectionLevelManager detectionManager;
    public float penaltyAmount = 15f;
    private bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive || other.CompareTag("Player") == false) return;

        detectionManager.AddPenalty(penaltyAmount);
        Debug.LogWarning("Red light violation detected!");

        if (WarningUIManager.Instance != null)
        {
            WarningUIManager.Instance.ShowWarning("You ran a red light!");
        }

        isActive = false; 
    }

    public void ActivateTrigger() => isActive = true;
    public void DeactivateTrigger() => isActive = false;
}
