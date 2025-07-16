using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject pauseMenuPanel;
    public GameObject optionsPanel;
    public GameObject helpPanel;

    [Header("Buttons")]
    public Button resumeButton;
    public Button returnToLobbyButton;
    public Button optionsButton;
    public Button helpButton;

    [Header("Options UI")]
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Button backFromOptionsButton;
    public Button backFromHelpButton;

    private bool isPaused = false;

    void Start()
    {
        pauseMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        helpPanel.SetActive(false);

        
        resumeButton.onClick.AddListener(ResumeGame);
        returnToLobbyButton.onClick.AddListener(ReturnToLobby);
        optionsButton.onClick.AddListener(OpenOptions);
        helpButton.onClick.AddListener(OpenHelp);

        
        backFromOptionsButton.onClick.AddListener(CloseOptions);
        backFromHelpButton.onClick.AddListener(CloseHelp);

        
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                PauseGame();
            else
                ResumeGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.volume = 0f;
        isPaused = true;
        pauseMenuPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        isPaused = false;
        pauseMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        helpPanel.SetActive(false);
    }

    void ReturnToLobby()
    {
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        SceneManager.LoadScene("MainLobby"); 
    }

    void OpenOptions()
    {
        pauseMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    void CloseOptions()
    {
        optionsPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
    }

    void OpenHelp()
    {
        pauseMenuPanel.SetActive(false);
        helpPanel.SetActive(true);
    }

    void CloseHelp()
    {
        helpPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
    }

    // Volume Controls
    void SetMasterVolume(float value)
    {
        AudioListener.volume = value; 
    }

    void SetMusicVolume(float value)
    {
        
        Debug.Log("Set music volume to: " + value);
    }

    void SetSFXVolume(float value)
    {
        
        Debug.Log("Set SFX volume to: " + value);
    }
}
