using UnityEngine;

public class RedLightDetector : MonoBehaviour
{
    public AutoTrafficSetController autoController; 
    public DetectionLevelManager detectionManager;   
    public string vehicleTag = "Player";            

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
                detectionManager.AddPenalty(20f); 
                Debug.Log("add penalty is working");
            }
            else
            {
                Debug.LogWarning("DetectionLevelManager is NOT assigned!");
            }
        }
    }
}
