using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignInfoManager : MonoBehaviour
{
    public GameObject signInfoPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public Image signImage; // 🆕 Add this in Inspector
    public Button continueButton;

    private bool isShowingInfo = false;

    void Start()
    {
        if (continueButton != null)
            continueButton.onClick.AddListener(CloseInfo);
    }

    // 🆕 Overloaded method with image
    public void ShowSignInfo(string title, string description, Sprite imageSprite)
    {
        titleText.text = title;
        descriptionText.text = description;

        if (signImage != null)
        {
            signImage.sprite = imageSprite;
            signImage.gameObject.SetActive(true);
        }

        signInfoPanel.SetActive(true);
        Time.timeScale = 0f;
        isShowingInfo = true;
    }

    public void CloseInfo()
    {
        Debug.Log("CloseInfo() called from button!");
        signInfoPanel.SetActive(false);
        Time.timeScale = 1f;
        isShowingInfo = false;
        Debug.Log("Continue clicked: Info panel closed.");
    }

    public bool IsShowingInfo()
    {
        return isShowingInfo;
    }
}
