using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    public Slider loadingBar;
    public TextMeshProUGUI loadingText;

    void Start()
    {
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        string targetScene = PlayerPrefs.GetString("TargetScene", "Main Game"); // Default to GameScene
        AsyncOperation operation = SceneManager.LoadSceneAsync(targetScene);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            if (loadingBar != null) loadingBar.value = progress;
            if (loadingText != null) loadingText.text = $"Loading... {Mathf.RoundToInt(progress * 100)}%";
            yield return null;
        }
    }
}
