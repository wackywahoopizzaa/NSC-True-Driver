using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance;

    public AudioClip defaultMusic;      // Main menu, lobby, etc.
    public AudioClip tutorialMusic;     // Unique music for tutorial

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
            audioSource.loop = true;

            SceneManager.sceneLoaded += OnSceneLoaded;
            PlayMusicForScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.name);
    }

    void PlayMusicForScene(string sceneName)
    {
        if (sceneName == "Tutorial") 
        {
            if (audioSource.clip != tutorialMusic)
            {
                audioSource.clip = tutorialMusic;
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.clip != defaultMusic)
            {
                audioSource.clip = defaultMusic;
                audioSource.Play();
            }
        }
    }
}
