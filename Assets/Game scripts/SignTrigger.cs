using UnityEngine;

public class SignTrigger : MonoBehaviour
{
    public string signTitle = "Stop Sign";
    [TextArea]
    public string signDescription = "This sign means you must stop completely and yield to traffic before proceeding.";

    private bool hasBeenShown = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasBeenShown)
        {
            SignInfoManager manager = FindObjectOfType<SignInfoManager>();
            if (manager != null && !manager.IsShowingInfo())
            {
                manager.ShowSignInfo(signTitle, signDescription);
                hasBeenShown = true;
            }
        }
    }
}
