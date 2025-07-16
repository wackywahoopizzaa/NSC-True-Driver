using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] allCars; 

    void Start()
    {
        string selectedCarName = PlayerPrefs.GetString("SelectedCar", "");
        bool found = false;

        foreach (GameObject car in allCars)
        {
            if (car.name == selectedCarName)
            {
                car.SetActive(true);
                found = true;
                Debug.Log("Activated car: " + car.name);
            }
            else
            {
                car.SetActive(false);
            }
        }

        if (!found)
        {
            Debug.LogWarning("No car matched. Defaulting to first car.");
            if (allCars.Length > 0)
                allCars[0].SetActive(true);
        }
    }
}
