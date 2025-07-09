using UnityEngine;
using System.Collections.Generic;

public class CarLoader : MonoBehaviour
{
    public List<GameObject> carModelsInScene; // Drag all car GameObjects placed in the scene here

    void Start()
    {
        string selectedCarID = PlayerPrefs.GetString("SelectedCarID", "Toyota Supra MK4");

        bool found = false;

        foreach (GameObject car in carModelsInScene)
        {
            if (car.name == selectedCarID)
            {
                car.SetActive(true);
                found = true;
                Debug.Log("Activated car: " + selectedCarID);
            }
            else
            {
                car.SetActive(false);
            }
        }

        if (!found)
        {
            Debug.LogWarning("Selected car not found in scene: " + selectedCarID);
        }
    }
}
