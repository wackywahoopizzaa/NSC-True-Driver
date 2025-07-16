using UnityEngine;

public class ObjectiveArrow : MonoBehaviour
{
    private Transform targetObjective;
    private Transform player;

    void Start()
    {
        FindPlayer();
    }

    void Update()
    {
        if (player == null || targetObjective == null) return;

        
        transform.position = player.position + Vector3.up * 3f;

        
        Vector3 direction = (targetObjective.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void SetTarget(Transform newTarget)
    {
        targetObjective = newTarget;
    }

    void FindPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject car in players)
        {
            if (car.activeInHierarchy)
            {
                player = car.transform;
                break;
            }
        }
    }
}
