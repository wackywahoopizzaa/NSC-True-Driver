using UnityEngine;

public class MissionGPSLine : MonoBehaviour
{
    private Transform playerTransform;
    private Transform targetTransform;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
        }

        if (MissionManager.Instance == null || MissionManager.Instance.currentMission == null || playerTransform == null)
        {
            lineRenderer.enabled = false;
            return;
        }

        int currentObjective = MissionManager.Instance.GetCurrentObjectiveIndex();
        Objective[] objectives = MissionManager.Instance.currentMission.objectives;

        if (currentObjective >= objectives.Length)
        {
            lineRenderer.enabled = false;
            return;
        }

        targetTransform = objectives[currentObjective].targetPoint;

        if (targetTransform != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, playerTransform.position + Vector3.up * 2f);
            lineRenderer.SetPosition(1, targetTransform.position + Vector3.up * 2f);
            Debug.Log("Drawing GPS line from " + playerTransform.name + " to " + targetTransform.name);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}
