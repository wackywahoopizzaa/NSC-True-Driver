using UnityEngine;

[CreateAssetMenu(menuName = "Mission System/Mission")]
public class MissionData : ScriptableObject
{
    public string missionName;
    [TextArea]
    public string description;
    public string sceneToLoad;
    public Objective[] objectives;
    public int rewardAmount;

    [Header("Mission Timer")]
    public float timeLimitInSeconds = 0f; 
}

[System.Serializable]
public class Objective
{
    public string objectiveName;
    public Transform targetPoint;
    public bool isCompleted;
}
