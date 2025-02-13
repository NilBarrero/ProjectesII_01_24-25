using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Transition : MonoBehaviour
{
    public string scene; // Nombre de la escena a cargar
    public string tutorial; // Nombre de la escena a cargar
    public Animator animator; // Asigna el Animator que controla la animaci�n de transici�n
    public float animationDuration = 1.0f; // Duraci�n de la animaci�n (aj�stala seg�n tu animaci�n)
    public AudioSource musicSource; // Fuente de audio para la m�sica de fondo
    public float fadeOutDuration = 1.0f; // Duraci�n del fade out en segundos
    public AudioClip clickSound; // Clip de audio que se reproducir� al hacer clic
    private string rutaArchivo; // Ruta del archivo de guardado
    public bool OneTimeOnly = false;

    private AudioSource audioSource; // Fuente de audio para reproducir el efecto de clic

    private void Awake()
    {
        // Este es el lugar correcto para inicializar variables antes de que el juego comience.
        rutaArchivo = Application.persistentDataPath + "/EntryLog.txt";
    }

    private void Start()
    {
        Debug.Log("Ruta del archivo EntryLog.txt: " + rutaArchivo);
        if (animator == null)
        {
            Debug.LogError("No se asign� un Animator. Por favor, asigna uno en el Inspector.");
        }

        if (musicSource == null)
        {
            Debug.LogWarning("No se asign� una fuente de audio. No se realizar� el fade out.");
        }

        // Configura el AudioSource para el sonido de clic
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        if (clickSound != null)
        {
            audioSource.clip = clickSound;
        }
        else
        {
            Debug.LogWarning("No se asign� un clip de audio para el clic.");
        }
    }

    private void OnMouseDown()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.Play(); // Reproduce el sonido de clic
        }
        if (OneTimeOnly)
        {
            check();
        }
        else
        {
            StartCoroutine(PlayAnimationAndChangeScene());
        }
    }

    private IEnumerator PlayAnimationAndChangeScene()
    {
        // Comienza el fade out del audio
        if (musicSource != null)
        {
            StartCoroutine(FadeOutMusic());
        }

        // Activa la animaci�n de transici�n
        if (animator != null)
        {
            animator.SetTrigger("StartTransition");
        }

        // Espera el tiempo que dura la animaci�n
        yield return new WaitForSeconds(animationDuration);

        // Cambia a la nueva escena
        SceneManager.LoadScene(scene);
    }

    private IEnumerator PlayAnimationAndChangeToTutorial()
    {
        // Comienza el fade out del audio
        if (musicSource != null)
        {
            StartCoroutine(FadeOutMusic());
        }

        // Activa la animaci�n de transici�n
        if (animator != null)
        {
            animator.SetTrigger("StartTransition");
        }

        // Espera el tiempo que dura la animaci�n
        yield return new WaitForSeconds(animationDuration);

        // Cambia a la nueva escena
        SceneManager.LoadScene(tutorial);
    }

    private IEnumerator FadeOutMusic()
    {
        float startVolume = musicSource.volume;

        for (float t = 0; t < fadeOutDuration; t += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0, t / fadeOutDuration);
            yield return null;
        }

        musicSource.volume = 0;
        musicSource.Stop(); // Detiene el audio completamente
    }

    private void check()
    {
        // Si el archivo no existe, lo creamos con un valor de "0"
        if (!File.Exists(rutaArchivo))
        {
            File.WriteAllText(rutaArchivo, "0");
            Debug.Log("Archivo creado con valor 0.");
        }

        // Leer el contenido del archivo
        string contenido = File.ReadAllText(rutaArchivo);
        Debug.Log("Valor actual del archivo: " + contenido); // Para depuraci�n

        if (contenido == "1")
        {
            StartCoroutine(PlayAnimationAndChangeScene());
        }
        else if (contenido == "0")
        {
            File.WriteAllText(rutaArchivo, "1"); // Se sobrescribe con "1"
            StartCoroutine(PlayAnimationAndChangeToTutorial());
        }
        else
        {
            Debug.LogError("El archivo tiene un valor inesperado: " + contenido);
        }
    }
}

