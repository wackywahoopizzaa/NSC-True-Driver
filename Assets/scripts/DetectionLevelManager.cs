using UnityEngine;
using UnityEngine.UI;

public class DetectionLevelManager : MonoBehaviour
{
    public Image detectionBar;      // UI slider that shows detection level
    public float maxLevel = 100f;    // Max cap
    private float targetLevel = 0f;  // Current penalty level

    public void AddPenalty(float amount)
    {
        targetLevel = Mathf.Clamp(targetLevel + amount, 0, maxLevel);

        if (detectionBar != null)
        {
            detectionBar.fillAmount = targetLevel / 100;
            Debug.Log("" + targetLevel + "");
        }
        else
        {
            Debug.LogWarning("Detection bar is not assigned!");
        }
    }
}
