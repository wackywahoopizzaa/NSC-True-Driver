using UnityEngine;
using TMPro;

public class SpeedLimitUI : MonoBehaviour
{
    public TextMeshProUGUI speedLimitText;

    private SpeedLimitDetector currentDetector;

  void Update()
{
    GameObject playerVehicle = GameObject.FindGameObjectWithTag("Player");

    if (playerVehicle != null)
    {
        SpeedLimitDetector detector = playerVehicle.GetComponentInChildren<SpeedLimitDetector>();
        if (detector != null)
        {
            if (detector != currentDetector)
            {
                currentDetector = detector;
            }
            speedLimitText.text = "Speed Limit: " + currentDetector.GetCurrentSpeedLimit() + " km/h";
            return;
        }
    }

    speedLimitText.text = "Speed Limit: N/A";
}

}
