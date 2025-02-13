using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Transition : MonoBehaviour
{
    public string scene; // Nombre de la escena a cargar
    public string tutorial; // Nombre de la escena a cargar
    public Animator animator; // Asigna el Animator que controla la animación de transición
    public float animationDuration = 1.0f; // Duración de la animación (ajústala según tu animación)
    public AudioSource musicSource; // Fuente de audio para la música de fondo
    public float fadeOutDuration = 1.0f; // Duración del fade out en segundos
    public AudioClip clickSound; // Clip de audio que se reproducirá al hacer clic
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
            Debug.LogError("No se asignó un Animator. Por favor, asigna uno en el Inspector.");
        }

        if (musicSource == null)
        {
            Debug.LogWarning("No se asignó una fuente de audio. No se realizará el fade out.");
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
            Debug.LogWarning("No se asignó un clip de audio para el clic.");
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

        // Activa la animación de transición
        if (animator != null)
        {
            animator.SetTrigger("StartTransition");
        }

        // Espera el tiempo que dura la animación
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

        // Activa la animación de transición
        if (animator != null)
        {
            animator.SetTrigger("StartTransition");
        }

        // Espera el tiempo que dura la animación
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
        Debug.Log("Valor actual del archivo: " + contenido); // Para depuración

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

