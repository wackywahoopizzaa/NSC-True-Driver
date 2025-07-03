using UnityEngine;

public class LobbyCarSwitcher : MonoBehaviour
{
    public GameObject[] cars;       // Assign car models in Inspector
    private int currentCarIndex = 0;

    void Start()
    {
        // Load saved car index (default to 0)
        currentCarIndex = PlayerPrefs.GetInt("SelectedCarIndex", 0);
        ShowCar(currentCarIndex);
    }

    public void ShowNextCar()
    {
        currentCarIndex = (currentCarIndex + 1) % cars.Length;
        ShowCar(currentCarIndex);
        SaveSelection();
    }

    public void ShowPreviousCar()
    {
        currentCarIndex--;
        if (currentCarIndex < 0)
            currentCarIndex = cars.Length - 1;

        ShowCar(currentCarIndex);
        SaveSelection();
    }

    private void ShowCar(int index)
    {
        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(i == index);
        }
    }

    public void SaveSelection()
    {
        PlayerPrefs.SetInt("SelectedCarIndex", currentCarIndex);
        PlayerPrefs.Save();
    }

    public int GetSelectedCarIndex()
    {
        return currentCarIndex;
    }
}
