using UnityEngine;

public class CashManager : MonoBehaviour
{
    public static CashManager Instance;

    public int currentCash = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadCash(); // Load saved cash value
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCash(int amount)
    {
        currentCash += amount;
        SaveCash();
        UIManager.Instance?.UpdateCashUI(currentCash);
        Debug.Log("Cash Added: " + amount);
    }

    public bool SpendCash(int amount)
    {
        if (currentCash >= amount)
        {
            currentCash -= amount;
            SaveCash();
            UIManager.Instance?.UpdateCashUI(currentCash);
            Debug.Log("Cash Spent: " + amount);
            return true;
        }
        else
        {
            Debug.LogWarning("Not enough cash!");
            return false;
        }
    }

    private void SaveCash()
    {
        PlayerPrefs.SetInt("PlayerCash", currentCash);
        PlayerPrefs.Save();
    }

    private void LoadCash()
    {
        currentCash = PlayerPrefs.GetInt("PlayerCash", 0); // Default to 0
    }

    // Optional: for debugging/resetting
    public void ResetCash()
    {
        currentCash = 0;
        SaveCash();
        UIManager.Instance?.UpdateCashUI(currentCash);
    }
    // For testing only: add cash by pressing a key
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.T)) // Press T to add test money
        {
            AddCash(1000); // Adds 1000 cash for testing
            Debug.Log("Test cash added: 1000");
        }
}

}
