using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MissionUIManager : MonoBehaviour
{
    public static MissionUIManager Instance;

    public TextMeshProUGUI missionNameText;
    public TextMeshProUGUI missionDescriptionText;
    public Button startButton;

    private string sceneToLoad;

    void Awake()
    {
        Instance = this;
        startButton.gameObject.SetActive(false);
    }

    public void ShowMissionDetails(MissionData mission)
    {
        missionNameText.text = mission.missionName;
        missionDescriptionText.text = mission.missionDescription;
        sceneToLoad = mission.sceneToLoad;
        startButton.gameObject.SetActive(true);
    }

    public void StartMission()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
    public class MissionPoint : MonoBehaviour
    {
        public MissionData missionData;

        public void SelectMission()
        {
            if (missionData != null)
            {
                MissionUIManager.Instance.ShowMissionDetails(missionData);
            }
        }
    }

}
