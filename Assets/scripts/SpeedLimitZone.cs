using UnityEngine;

public class SpeedLimitZone : MonoBehaviour
{
    public float zoneSpeedLimit = 40f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log($"SpeedLimitZone: Entered by {other.name}");

        SpeedLimitDetector detector = other.GetComponentInParent<SpeedLimitDetector>();
        if (detector != null)
        {
            detector.UpdateSpeedLimit(zoneSpeedLimit);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log($"SpeedLimitZone: Exited by {other.name}");

        SpeedLimitDetector detector = other.GetComponentInParent<SpeedLimitDetector>();
        if (detector != null)
        {
            detector.ResetToDefaultLimit();
        }
    }
}
