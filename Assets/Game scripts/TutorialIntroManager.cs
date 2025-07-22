using UnityEngine;

public class TutorialIntroManager : MonoBehaviour
{
    public GameObject controlsPanel;
    private const string ControlsSeenKey = "HasSeenTutorialControls";

    void Start()
    {
        // Check if the player has seen the tutorial before
        bool hasSeen = PlayerPrefs.GetInt(ControlsSeenKey, 0) == 1;

        if (!hasSeen && controlsPanel != null)
        {
            controlsPanel.SetActive(true);
        }
        else if (controlsPanel != null)
        {
            controlsPanel.SetActive(false);
        }
    }

    // Called by the "Continue" button
    public void OnContinuePressed()
    {
        PlayerPrefs.SetInt(ControlsSeenKey, 1);
        PlayerPrefs.Save();

        if (controlsPanel != null)
            controlsPanel.SetActive(false);
    }

}
