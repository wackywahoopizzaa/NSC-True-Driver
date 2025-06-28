using UnityEngine;

public class SpeedLimitDetector : MonoBehaviour
{
    public float defaultSpeedLimit = 60f;
    private float currentSpeedLimit;
    private bool inZone = false;
    private bool zonePenaltyGiven = false;

    public DetectionLevelManager detectionManager;
    public Rigidbody vehicleRigidbody;

    public float checkInterval = 0.5f;
    private float checkCooldown = 0f;
    public float penaltyAmount = 10f;

    void Start()
    {
        currentSpeedLimit = defaultSpeedLimit;
        checkCooldown = checkInterval;
    }

    void Update()
    {
        if (vehicleRigidbody == null || detectionManager == null) return;

        checkCooldown -= Time.deltaTime;
        if (checkCooldown <= 0f)
        {
            checkCooldown = checkInterval;

            float speed = vehicleRigidbody.velocity.magnitude * 3.6f; // m/s to km/h
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
