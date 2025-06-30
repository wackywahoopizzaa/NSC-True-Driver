using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI cashText;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateCashUI(int amount)
    {
        if (cashText != null)
            cashText.text = "Cash: $" + amount.ToString("N0");
    }
    void Start()
    {
        UpdateCashUI(CashManager.Instance.currentCash);
    }

}
