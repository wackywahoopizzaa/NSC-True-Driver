using UnityEngine;
using TMPro;

public class WarningUIManager : MonoBehaviour
{
    public static WarningUIManager Instance;

    public TextMeshProUGUI warningText;
    public float displayDuration = 2f;

    private float timer;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (warningText != null)
        {
            warningText.gameObject.SetActive(false);
        }
    }

    public void ShowWarning(string message)
    {
        if (warningText == null) return;

        warningText.text = message;
        warningText.gameObject.SetActive(true);
        timer = displayDuration;
    }

    void Update()
    {
        if (warningText != null && warningText.gameObject.activeSelf)
        {
            timer -= Time.unscaledDeltaTime;
            if (timer <= 0f)
            {
                warningText.gameObject.SetActive(false);
            }
        }
    }
}
