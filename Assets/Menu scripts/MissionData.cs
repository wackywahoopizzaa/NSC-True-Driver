using UnityEngine;

[CreateAssetMenu(fileName = "NewMission", menuName = "Mission")]
public class MissionData : ScriptableObject
{
    public string missionName;
    public string missionDescription;
    public string sceneToLoad;
}
