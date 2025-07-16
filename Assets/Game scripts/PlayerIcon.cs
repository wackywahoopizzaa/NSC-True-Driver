using UnityEngine;

public class PlayerIconRotation : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (player == null) return;
        transform.rotation = Quaternion.Euler(0f, 0f, -player.eulerAngles.y);
    }
}
