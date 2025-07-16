using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MissionTimer : MonoBehaviour
{
    public float missionDuration = 120f;
    private float timeRemaining;
    public TextMeshProUGUI timerText;
    public GameObject gameOverUI;

    private bool isGameOver = false;

    void Start()
    {
        timeRemaining = missionDuration;
        gameOverUI.SetActive(false);
        Time.timeScale = 1f; 
    }

    void Update()
    {
        if (isGameOver) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining > 0)
        {
            UpdateTimerDisplay();
        }
        else
        {
            TriggerGameOver();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f; 
        gameOverUI.SetActive(true);
    }

    public void RetryMission()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainLobby"); 
    }
}
