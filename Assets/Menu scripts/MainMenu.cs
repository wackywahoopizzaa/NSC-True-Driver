using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Replace "GameScene" with your actual gameplay scene name
        SceneManager.LoadScene("Main Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();

        // NOTE: This won't quit the game in the Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public OptionsMenu optionsMenu;

    public void OpenOptions()
    {
        optionsMenu.OpenOptions();
    }

}
