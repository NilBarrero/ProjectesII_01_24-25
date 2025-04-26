using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    [SerializeField] private FadeInOutMusic fadeMusic; // Reference to the FadeInOutMusic script.
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private AudioMixer audioMixer;

    private static Options instance; // Singleton pattern to avoid duplicates.

    void Awake()
    {
        // Implement the Singleton pattern.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Do not destroy this object when changing scenes.
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates.
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reassign references when changing scenes.
        mainMenu = GameObject.Find("MenuPrincipal"); // Adjust the name according to your scene.
        optionsMenu = GameObject.Find("Options"); // Adjust the name according to your scene.
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void Exit()
    {
        if (mainMenu != null)
        {
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
        }
    }

    public void FullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void Sound(float volume)
    {
        audioMixer.SetFloat("MusicVol", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("Volume", volume); // Save the volume.
        PlayerPrefs.Save();
    }

    void Start()
    {
        // Load saved volume at startup.
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            audioMixer.SetFloat("MusicVol", savedVolume);
        }
    }
}
