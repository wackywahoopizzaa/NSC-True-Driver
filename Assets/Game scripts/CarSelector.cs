using UnityEngine;

public class CarSelector : MonoBehaviour
{
    public void SelectCar(string carName)
    {
        PlayerPrefs.SetString("SelectedCar", carName);
        PlayerPrefs.Save();
        Debug.Log("Car Selected: " + carName);
    }
}
