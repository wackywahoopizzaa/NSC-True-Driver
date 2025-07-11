using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;

    public int totalObjectives = 3;
    private int currentObjective = 0;

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
            NotificationManager.Instance.ShowNotification($" Objective {index + 1} Complete");

            if (currentObjective >= totalObjectives)
            {
                NotificationManager.Instance.ShowNotification(" Mission Complete!");
                Debug.Log("Mission complete!");
                // Reward logic here
            }
        }
        else
        {
            Debug.LogWarning($"Wrong objective! Expected {currentObjective}, but triggered {index}");
        }
    }

}
