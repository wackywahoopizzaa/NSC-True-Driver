using UnityEngine;
using System.Collections.Generic;

public class GarageCarLoader : MonoBehaviour
{
    public List<GameObject> carPrefabs; // Assign all car prefabs (or models) here in Inspector
    public Transform spawnPoint;        // Where to place the cars

    private void Start()
    {
        LoadOwnedCars();
    }

    void LoadOwnedCars()
    {
        foreach (GameObject carPrefab in carPrefabs)
        {
            string carID = carPrefab.name; // Make sure prefab name matches carID
            if (PlayerPrefs.GetInt("CarOwned_" + carID, 0) == 1)
            {
                GameObject car = Instantiate(carPrefab, spawnPoint.position, spawnPoint.rotation);
                car.SetActive(true);
                break; // Show only one car at a time
            }
        }
    }
}
