using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.SetString("MainLobby", "MainLobby");
        SceneManager.LoadScene("Loading Screen");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();

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
