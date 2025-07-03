using UnityEngine;
using UnityEngine.SceneManagement;

public class GarageUIManager : MonoBehaviour
{
public LobbyCarSwitcher carSwitcher;

    public void ReturnToLobby()
    {
        carSwitcher.SaveSelection();
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainLobby");
    }

}
