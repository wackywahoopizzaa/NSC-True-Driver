using UnityEngine;
using UnityEngine.UI;

public class TutorialIntroManager : MonoBehaviour
{
    public GameObject controlsPanel; 
    private const string ControlsSeenKey = "HasSeenTutorialControls";

    void Start()
    {
        if (PlayerPrefs.GetInt(ControlsSeenKey, 0) == 0)
        {
            
            if (controlsPanel != null)
                controlsPanel.SetActive(true);

            Time.timeScale = 0f;
            AudioListener.volume = 0f;
        }
        else
        {
            
            if (controlsPanel != null)
                controlsPanel.SetActive(false);

            Time.timeScale = 1f;
            AudioListener.volume = 1f;
        }
    }

    public void OnContinuePressed()
    {
        
        PlayerPrefs.SetInt(ControlsSeenKey, 1);
        PlayerPrefs.Save();

        
        if (controlsPanel != null)
            controlsPanel.SetActive(false);

        Time.timeScale = 1f;
        AudioListener.volume = 1f;
    }

    
    public void ResetTutorialSeenFlag()
    {
        PlayerPrefs.DeleteKey(ControlsSeenKey);
    }
}
