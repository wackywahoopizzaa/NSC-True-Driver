using UnityEngine;

[CreateAssetMenu(menuName = "Mission System/Mission")]
public class MissionData : ScriptableObject
{
    public string missionName;
    public string description;
    public Sprite missionImage;
    public string sceneToLoad;
    public Objective[] objectives;
     public int rewardAmount;
}

[System.Serializable]
public class Objective
{
    public string objectiveName;
    public Transform targetPoint; // where to go
    public bool isCompleted;
}
