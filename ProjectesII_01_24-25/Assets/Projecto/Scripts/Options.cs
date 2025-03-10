using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    [SerializeField] private FadeInOutMusic fadeMusic; // Referencia al script FadeInOutMusic.
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject options;
    [SerializeField] private AudioMixer audioMixer;

    private static Options instance; // Patrón Singleton para evitar duplicados.

    void Awake()
    {
        // Implementar el patrón Singleton.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // No destruir este objeto al cambiar de escena.
        }
        else
        {
            Destroy(gameObject); // Evitar duplicados.
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reasignar las referencias al cambiar de escena.
        menuPrincipal = GameObject.Find("MenuPrincipal"); // Ajusta el nombre según tu escena.
        options = GameObject.Find("Options"); // Ajusta el nombre según tu escena.
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
        if (menuPrincipal != null)
        {
            menuPrincipal.SetActive(true);
            options.SetActive(false);
        }
    }

    public void FullScren(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void Sound(float sound)
    {
        audioMixer.SetFloat("Sound", sound);
        PlayerPrefs.SetFloat("Volume", sound); // Guardar el volumen.
        PlayerPrefs.Save();
    }

    void Start()
    {
        // Cargar el volumen guardado al iniciar.
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            audioMixer.SetFloat("Sound", savedVolume);
        }
    }
}