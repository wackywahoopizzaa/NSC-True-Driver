using UnityEngine;
using TMPro;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;

    public MissionData currentMission;
    private int currentObjective = 0;

    private int originalReward = 0;
    private int currentReward = 0;

    public GameObject missionCompletePanel;
    public TextMeshProUGUI rewardText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        currentMission = MissionRuntimeData.currentMission;
    }

    void Start()
    {
        if (currentMission != null)
        {
            originalReward = currentMission.rewardAmount;
            currentReward = originalReward;
        }
        else
        {
            Debug.LogWarning("MissionManager: currentMission is not assigned!");
        }
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

    public void ReduceRewardByPercentage(float percent)
    {
        int reduction = Mathf.RoundToInt(originalReward * percent);
        currentReward = Mathf.Max(0, currentReward - reduction);
        Debug.Log($"Reward reduced by {percent * 100}%: Now ${currentReward}");
    }

    void CompleteMission()
    {
        NotificationManager.Instance.ShowNotification("Mission Complete!");
        Debug.Log("Mission complete!");

        CashManager.Instance.AddCash(currentReward);

        if (missionCompletePanel != null)
        {
            missionCompletePanel.SetActive(true);

            if (rewardText != null)
            {
                rewardText.text = $"Reward: ${currentReward}\nTotal Cash: ${CashManager.Instance.currentCash}";
            }
        }

        Time.timeScale = 0f;
        AudioListener.volume = 0f;
    }

    public int GetCurrentReward()
    {
        return currentReward;
    }
    public int GetCurrentObjectiveIndex()
{
    return currentObjective;
}

}
