using UnityEngine;

public class SpeedLimitZone : MonoBehaviour
{
    public float zoneSpeedLimit = 40f;

    private StandaloneSpeedLimitDetector detector;

    private void Start()
    {
        detector = FindObjectOfType<StandaloneSpeedLimitDetector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (detector != null)
        {
            detector.UpdateSpeedLimit(zoneSpeedLimit);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (detector != null)
        {
            detector.ResetToDefaultLimit();
        }
    }
}
