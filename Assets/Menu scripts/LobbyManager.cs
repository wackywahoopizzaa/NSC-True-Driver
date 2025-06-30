using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public void OpenGarage()
    {
        SceneManager.LoadScene("Garage");
    }

    public void OpenDealership()
    {
        SceneManager.LoadScene("CarDealership");
    }

    public void OpenMissionMap()
    {
        SceneManager.LoadScene("MissionMap");
    }
}
