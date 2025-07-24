using UnityEngine;

public class MissionGPSPointer : MonoBehaviour
{
    private Transform playerTransform;
    private Transform targetTransform;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (playerTransform == null || MissionManager.Instance == null || MissionManager.Instance.currentMission == null)
            return;

        int currentObjective = MissionManager.Instance.GetCurrentObjectiveIndex();

        Objective[] objectives = MissionManager.Instance.currentMission.objectives;
        if (currentObjective < objectives.Length)
        {
            targetTransform = objectives[currentObjective].targetPoint;
        }

        if (targetTransform != null)
        {
            Vector3 direction = targetTransform.position - playerTransform.position;
            direction.y = 0f;

            if (direction != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
            }
        }
    }
}
