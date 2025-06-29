using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.SetString("Main Game", "GameScene"); // Set your target scene name
        SceneManager.LoadScene("Loading Screen");
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
