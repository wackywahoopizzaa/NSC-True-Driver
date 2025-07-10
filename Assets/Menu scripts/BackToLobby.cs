using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToLobby : MonoBehaviour
{
    public void LoadLobbyScene()
    {
        SceneManager.LoadScene("MainLobby");
    }
}
