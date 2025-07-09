using UnityEngine;

[CreateAssetMenu(fileName = "NewMission", menuName = "Mission/MissionData")]
public class MissionData : ScriptableObject
{
    public string missionName;
    public string description;
    public string sceneToLoad;
}
