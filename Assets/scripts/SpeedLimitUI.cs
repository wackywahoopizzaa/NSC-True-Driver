using UnityEngine;
using TMPro;

public class SpeedLimitUI : MonoBehaviour
{
    public TextMeshProUGUI speedLimitText;

    private StandaloneSpeedLimitDetector detector;

    void Start()
    {
        detector = FindObjectOfType<StandaloneSpeedLimitDetector>();
        if (detector == null)
        {
            Debug.LogWarning("SpeedLimitUI: No StandaloneSpeedLimitDetector found in the scene.");
        }
    }

    void Update()
    {
        if (detector != null)
        {
            speedLimitText.text = "Speed Limit: " + detector.GetCurrentSpeedLimit() + " km/h";
        }
        else
        {
            speedLimitText.text = "Speed Limit: N/A";
        }
    }
}
