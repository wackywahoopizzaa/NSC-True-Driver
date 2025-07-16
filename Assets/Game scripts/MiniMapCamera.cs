using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    public string playerTag = "Player"; 
    public float height = 50f;
    private Transform player;

    void Update()
    {
        if (player == null)
        {
            
            GameObject found = GameObject.FindWithTag(playerTag);
            if (found != null && found.activeInHierarchy)
            {
                player = found.transform;
            }
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 newPosition = player.position;
        newPosition.y += height;
        transform.position = newPosition;

        
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
