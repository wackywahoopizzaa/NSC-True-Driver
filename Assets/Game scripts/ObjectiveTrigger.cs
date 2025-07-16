using UnityEngine;

public class MissionTrigger : MonoBehaviour
{
    public int objectiveIndex; 
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return; 
        if (!other.CompareTag("Player")) return;

        MissionManager.Instance.ReachObjective(objectiveIndex);
        triggered = true;
    }
}
