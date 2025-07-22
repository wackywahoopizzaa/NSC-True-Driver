using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DetectionLevelManager : MonoBehaviour
{
    public Image detectionBar;
    public GameObject gameOverUI;
    public TextMeshProUGUI levelText; // For showing "Level 1" or "Level 2"

    public float maxLevel = 100f;
    private float targetLevel = 0f;

    private int currentLevel = 0; // Level 0 → no strikes, Level 1 → first fill, Level 2 → second fill
    private const int maxLevels = 2;
    private bool isGameOver = false;
    public MissionManager missionManager;

    void Start()
    {
        targetLevel = 0f;
        currentLevel = 0;
        UpdateLevelText();
        gameOverUI.SetActive(false);
    }

    public void AddPenalty(float amount)
    {
        if (isGameOver) return;

        targetLevel = Mathf.Clamp(targetLevel + amount, 0, maxLevel);

        if (detectionBar != null)
        {
            detectionBar.fillAmount = targetLevel / maxLevel;
        }

        if (targetLevel >= maxLevel)
        {
            currentLevel++;

            if (currentLevel >= maxLevels)
            {
                TriggerGameOver();
            }
            else
            {
                Debug.Log($"Detection Level {currentLevel} reached!");
                targetLevel = 0f;
                detectionBar.fillAmount = 0f;
                UpdateLevelText();
            }
        }
    if (missionManager != null)
    {
        MissionManager.Instance?.ReduceRewardByPercentage(0.1f);
    }
    else
    {
        Debug.LogWarning("MissionManager is not assigned in DetectionLevelManager.");
    }
    }

    void TriggerGameOver()
    {
        Debug.Log("Game Over triggered due to max detection level.");
        isGameOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.volume = 0f;
    }

    void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = $"Level {currentLevel}";
        }
    }
}
