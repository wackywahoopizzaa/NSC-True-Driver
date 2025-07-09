using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroLoader : MonoBehaviour
{
    public float introDuration = 5f; // seconds before auto-transition
    public Button skipButton;
    private bool hasSkipped = false;

    void Start()
    {
        if (skipButton != null)
        {
            skipButton.onClick.AddListener(SkipIntro);
        }

        // Start automatic transition
        Invoke("LoadMainMenu", introDuration);
    }

    void SkipIntro()
    {
        if (hasSkipped) return;

        hasSkipped = true;
        CancelInvoke("LoadMainMenu");
        LoadMainMenu();
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
