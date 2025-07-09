using UnityEngine;
using UnityEngine.UI;

public class MissionButton : MonoBehaviour
{
    public MissionData missionData;
    public MissionDetailUI detailUI;

    public void OnClick()
    {
        Debug.Log("Mission button clicked: " + missionData.missionName);
        detailUI.ShowMissionDetails(missionData);
    }

    
}
