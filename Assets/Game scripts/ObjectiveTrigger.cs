using UnityEngine;

public class MissionTrigger : MonoBehaviour
{
    public int objectiveIndex; // Set this in the inspector (0 for first, 1 for second, etc.)
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return; // prevent double triggering
        if (!other.CompareTag("Player")) return;

        MissionManager.Instance.ReachObjective(objectiveIndex);
        triggered = true;
    }
}
