using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MissionButton : MonoBehaviour
{
    public MissionData missionData;
    public MissionDetailUI detailUI;

    public void OnClick()
    {
        Debug.Log("Mission button clicked: " + missionData.missionName);

        
        detailUI.ShowMissionDetails(missionData);
    }

    public void OnConfirmStartMission()
{
    Debug.Log("Mission selected: " + missionData.missionName); 
    MissionRuntimeData.currentMission = missionData;

    PlayerPrefs.SetString("TargetScene", missionData.sceneToLoad);
    PlayerPrefs.Save();
    SceneManager.LoadScene("Loading Screen");
}


}
