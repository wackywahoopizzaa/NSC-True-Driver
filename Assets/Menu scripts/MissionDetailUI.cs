using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MissionDetailUI : MonoBehaviour
{
    public TextMeshProUGUI missionNameText;
    public TextMeshProUGUI descriptionText;
    public Image missionImage;
    public GameObject detailPanel;
    private string sceneToLoad;

    public void ShowMissionDetails(MissionData data)
    {
        Debug.Log("Showing mission: " + data.missionName);
        missionNameText.text = data.missionName;
        descriptionText.text = data.description;
        sceneToLoad = data.sceneToLoad;

        detailPanel.SetActive(true);
    }

    public void StartMission()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            PlayerPrefs.SetString("TargetScene", sceneToLoad);
            SceneManager.LoadScene("Loading Screen"); 
        }
    }

}
