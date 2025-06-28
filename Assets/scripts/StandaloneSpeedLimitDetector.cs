using UnityEngine;

public class StandaloneSpeedLimitDetector : MonoBehaviour
{
    public float defaultSpeedLimit = 60f;
    private float currentSpeedLimit;
    private bool inZone = false;
    private bool zonePenaltyGiven = false;

    public DetectionLevelManager detectionManager;

    public float checkInterval = 0.5f;
    private float checkCooldown = 0f;
    public float penaltyAmount = 10f;

    private Rigidbody currentVehicleRb;

    void Start()
    {
        currentSpeedLimit = defaultSpeedLimit;
        checkCooldown = checkInterval;
    }

    void Update()
    {
        // Look for vehicle tagged "Player"
        GameObject playerVehicle = GameObject.FindGameObjectWithTag("Player");
        if (playerVehicle != null)
        {
            currentVehicleRb = playerVehicle.GetComponent<Rigidbody>();
        }
        else
        {
            currentVehicleRb = null;
        }

        // Skip if missing vehicle or detectionManager
        if (currentVehicleRb == null || detectionManager == null)
            return;

        // Speed check logic
        checkCooldown -= Time.deltaTime;
        if (checkCooldown <= 0f)
        {
            checkCooldown = checkInterval;

            float speed = currentVehicleRb.velocity.magnitude * 3.6f;
            Debug.Log("Current speed: " + speed + " km/h");

            if (inZone)
            {
                if (!zonePenaltyGiven && speed > currentSpeedLimit)
                {
                    detectionManager.AddPenalty(penaltyAmount);
                    zonePenaltyGiven = true;
                    Debug.LogWarning("Speeding in zone! Penalty applied.");
                }
            }
            else
            {
                if (speed > defaultSpeedLimit)
                {
                    detectionManager.AddPenalty(penaltyAmount);
                    Debug.LogWarning("Speeding outside zone! Penalty applied.");
                }
            }
        }
    }

    // These methods are called by SpeedLimitZone trigger
    public void UpdateSpeedLimit(float newLimit)
    {
        currentSpeedLimit = newLimit;
        inZone = true;
        zonePenaltyGiven = false;
        Debug.Log("Entered speed zone: " + newLimit + " km/h");
    }

    public void ResetToDefaultLimit()
    {
        currentSpeedLimit = defaultSpeedLimit;
        inZone = false;
        zonePenaltyGiven = false;
        Debug.Log("Exited speed zone. Reset to default limit: " + defaultSpeedLimit);
    }

    public float GetCurrentSpeedLimit()
    {
        return currentSpeedLimit;
    }
}
