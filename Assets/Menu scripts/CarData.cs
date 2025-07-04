using UnityEngine;

[CreateAssetMenu(fileName = "NewCar", menuName = "Car Dealer/Car Data")]
public class CarData : ScriptableObject
{
    public string carID;
    public string carName;
    public Sprite carImage;
    public int price;
    public GameObject carPrefab;
}
