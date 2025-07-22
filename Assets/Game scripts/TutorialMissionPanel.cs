using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class TutorialMissionPanel : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI rewardText;
    public TextMeshProUGUI timeLimitText;
    public Button readyButton;
    public TextMeshProUGUI countdownText;

   void Start()
{
    Time.timeScale = 0f;
    panel.SetActive(true);
    countdownText.gameObject.SetActive(false);

    var mission = MissionRuntimeData.currentMission;

    if (mission != null)
    {
        Debug.Log($"Loaded mission: {mission.missionName}, reward: {mission.rewardAmount}, timeLimit: {mission.timeLimitInSeconds}");

        titleText.text = mission.missionName;
        descriptionText.text = mission.description;
        rewardText.text = $"Reward: ${mission.rewardAmount}";

        int m = Mathf.FloorToInt(mission.timeLimitInSeconds / 60);
        int s = Mathf.FloorToInt(mission.timeLimitInSeconds % 60);
        timeLimitText.text = $"Time Limit: {m:00}:{s:00}";
    }
    else
    {
        Debug.LogWarning("MissionRuntimeData.currentMission is null!");
        titleText.text = "No Mission";
        descriptionText.text = "No Description";
        rewardText.text = "Reward: N/A";
        timeLimitText.text = "Time Limit: N/A";
    }

    readyButton.onClick.AddListener(() => StartCoroutine(StartCountdown()));
}

    IEnumerator StartCountdown()
    {
        panel.SetActive(false);
        countdownText.gameObject.SetActive(true);

        int count = 3;

        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }

        countdownText.text = "Go!";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.gameObject.SetActive(false);

        Time.timeScale = 1f;
    }
}