using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    void Awake()
    {
        LoadSettings();
        DontDestroyOnLoad(gameObject);

    }

    public void LoadSettings()
    {
        // Load volume
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        AudioListener.volume = savedVolume;

        // Load graphics quality
        int savedQuality = PlayerPrefs.GetInt("GraphicsQuality", QualitySettings.GetQualityLevel());
        QualitySettings.SetQualityLevel(savedQuality);
    }
}
