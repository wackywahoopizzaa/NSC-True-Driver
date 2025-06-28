using UnityEngine;

public class RedLightDetector : MonoBehaviour
{
    public AutoTrafficSetController autoController; // Reference to automatic traffic light system
    public DetectionLevelManager detectionManager;   // Reference to the penalty UI system
    public string vehicleTag = "Player";            // Tag for detecting vehicles

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered: " + other.name);

        if (!other.CompareTag(vehicleTag)) return;

        Debug.Log("Vehicle entered trigger");

        if (autoController != null && autoController.currentState == PhaseState.Stop)
        {
            Debug.Log("Red Light Violation Detected by: " + other.name);

            if (detectionManager != null)
            {
                detectionManager.AddPenalty(20f); // 👈 This raises the detection level
                Debug.Log("add penalty is working");
            }
            else
            {
                Debug.LogWarning("DetectionLevelManager is NOT assigned!");
            }
        }
    }
}
