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
            DontDestroyOnLoad(gameObject); // persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCash(int amount)
    {
        currentCash += amount;
        UIManager.Instance.UpdateCashUI(currentCash);
        Debug.Log("Cash Added: " + amount);
    }

    public bool SpendCash(int amount)
    {
        if (currentCash >= amount)
        {
            currentCash -= amount;
            UIManager.Instance.UpdateCashUI(currentCash);
            Debug.Log("Cash Spent: " + amount);
            return true;
        }
        else
        {
            Debug.LogWarning("Not enough cash!");
            return false;
        }
    }
}
