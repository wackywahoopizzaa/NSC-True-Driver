using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    void Awake()
    {
    
    if (!PlayerPrefs.HasKey("CarOwned_Toyota Supra MK4"))
        {
        PlayerPrefs.SetInt("CarOwned_Toyota Supra MK4", 1);
        PlayerPrefs.Save();
        Debug.Log("Default car ownership set.");
        }
    }

}
