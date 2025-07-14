using UnityEngine;
using TMPro;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;

    public MissionData currentMission;

    private int currentObjective = 0;

    public GameObject missionCompletePanel;
    public TextMeshProUGUI rewardText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ReachObjective(int index)
    {
        if (index == currentObjective)
        {
            currentObjective++;
            NotificationManager.Instance.ShowNotification($"Objective {index + 1} Complete");

            if (currentObjective >= currentMission.objectives.Length)
            {
                CompleteMission();
            }
        }
        else
        {
            Debug.LogWarning($"Wrong objective! Expected {currentObjective}, but triggered {index}");
        }
    }

    void CompleteMission()
    {
        NotificationManager.Instance.ShowNotification("Mission Complete!");
        Debug.Log("Mission complete!");

        CashManager.Instance.AddCash(currentMission.rewardAmount);

        if (missionCompletePanel != null)
        {
            missionCompletePanel.SetActive(true);

            if (rewardText != null)
            {
                rewardText.text = $"Reward: ${currentMission.rewardAmount}\nTotal Cash: ${CashManager.Instance.currentCash}";
            }
        }

        Time.timeScale = 0f;
        AudioListener.volume = 0f;
    }
}
