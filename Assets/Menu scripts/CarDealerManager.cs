using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class CarDealerManager : MonoBehaviour
{
    public List<GameObject> carDisplayPoints;
    public Transform spawnPoint;
    public List<CarData> availableCars;
    public GameObject currentCar;
    public GameObject buyButton;
    public GameObject selectButton;
    public TextMeshProUGUI carNameText;
    public TextMeshProUGUI priceText;
    private int currentIndex = 0;

    void Start()
    {
        int defaultIndex = 0; // fallback if not found

        for (int i = 0; i < availableCars.Count; i++)
        {
            if (availableCars[i].carName == "Toyota Supra MK4")
            {
                defaultIndex = i;
                break;
            }
        }

        ShowCar(defaultIndex);
    }



    public void ShowCar(int index)
    {
    if (index < 0 || index >= availableCars.Count || index >= carDisplayPoints.Count)
    {
        Debug.LogError("ShowCar: Index out of range. Index: " + index);
        return;
    }

    // Hide all cars
    foreach (GameObject car in carDisplayPoints)
        car.SetActive(false);

    // Show selected
    carDisplayPoints[index].SetActive(true);
    currentIndex = index;

    CarData carData = availableCars[index];
    carNameText.text = carData.carName;
    priceText.text = "$" + carData.price;

    bool owned = PlayerPrefs.GetInt("CarOwned_" + carData.carID, 0) == 1;
    buyButton.SetActive(!owned);
    selectButton.SetActive(owned);
    }




    public void NextCar() {
        currentIndex = (currentIndex + 1) % availableCars.Count;
        ShowCar(currentIndex);
    }

    public void PreviousCar() {
        currentIndex = (currentIndex - 1 + availableCars.Count) % availableCars.Count;
        ShowCar(currentIndex);
    }

    public void BuyCar()
    {
    CarData car = availableCars[currentIndex];

    if (CashManager.Instance.SpendCash(car.price))
        {
            PlayerPrefs.SetInt("CarOwned_" + car.carID, 1);
            PlayerPrefs.Save();

            Debug.Log("Car purchased: " + car.carName);

        // Refresh UI (switch Buy → Select)
            ShowCar(currentIndex);
        }
    else
        {
            Debug.LogWarning("Not enough cash to buy: " + car.carName);
        }
    }



    public void SelectCar()
    {
        CarData car = availableCars[currentIndex];
        PlayerPrefs.SetString("SelectedCarID", car.carID);
        PlayerPrefs.Save();
        Debug.Log("Car selected: " + car.carName);
    }
}
