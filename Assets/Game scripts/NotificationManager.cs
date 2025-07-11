using UnityEngine;
using TMPro;
using System.Collections;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager Instance;

    public TextMeshProUGUI notificationText;
    public float displayDuration = 2f;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ShowNotification(string message)
    {
        StopAllCoroutines();
        StartCoroutine(Show(message));
    }

    private IEnumerator Show(string message)
    {
        notificationText.text = message;
        notificationText.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayDuration);
        notificationText.gameObject.SetActive(false);
    }
}
