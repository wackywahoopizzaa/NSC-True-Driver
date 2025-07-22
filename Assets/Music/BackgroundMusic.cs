using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance;

    public AudioClip defaultMusic;
    public AudioClip tutorialMusic;

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
        if (scene.name == "MainLobby" || scene.name == "Main Menu")
    {
        AudioListener.volume = 1f;
    }
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
