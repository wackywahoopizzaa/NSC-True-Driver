using UnityEngine;
using System.Collections.Generic;

public class GarageCarLoader : MonoBehaviour
{
    public List<GameObject> allCarsInScene;     // Drag all car GameObjects here manually
    public GameObject nextButton;
    public GameObject previousButton;

    private List<GameObject> ownedCars = new List<GameObject>();
    private int currentIndex = 0;

    void Start()
    {
        LoadOwnedCars();
        UpdateUI();
    }

    void LoadOwnedCars()
    {
        foreach (GameObject car in allCarsInScene)
        {
            string carID = car.name;
            bool isOwned = PlayerPrefs.GetInt("CarOwned_" + carID, 0) == 1;

            if (isOwned)
                ownedCars.Add(car);
                Debug.Log("Checking ownership for: " + car.name + " → " + PlayerPrefs.GetInt("CarOwned_" + car.name, 0));

            car.SetActive(false); // Hide all cars at first
        }

        if (ownedCars.Count > 0)
        {
            currentIndex = 0;
            ownedCars[currentIndex].SetActive(true);
        }
        else
        {
            Debug.LogWarning("No owned cars found in the garage.");
        }
    }

    void UpdateUI()
    {
        bool hasMultipleCars = ownedCars.Count > 1;
        nextButton.SetActive(hasMultipleCars);
        previousButton.SetActive(hasMultipleCars);
    }

    public void ShowNextCar()
    {
        if (ownedCars.Count <= 1) return;

        ownedCars[currentIndex].SetActive(false);
        currentIndex = (currentIndex + 1) % ownedCars.Count;
        ownedCars[currentIndex].SetActive(true);
    }

    public void ShowPreviousCar()
    {
        if (ownedCars.Count <= 1) return;

        ownedCars[currentIndex].SetActive(false);
        currentIndex = (currentIndex - 1 + ownedCars.Count) % ownedCars.Count;
        ownedCars[currentIndex].SetActive(true);
    }
}
