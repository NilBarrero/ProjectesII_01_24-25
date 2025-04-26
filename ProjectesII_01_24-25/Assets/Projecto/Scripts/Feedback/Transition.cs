using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Transition : MonoBehaviour
{
    public string scene; // Nombre de la escena a cargar
    public string tutorial; // Nombre de la escena a cargar
    public Animator animator; // Asigna el Animator que controla la animación de transición
    public float animationDuration = 1.0f; // Duración de la animación
    public AudioSource musicSource; // Fuente de audio para la música de fondo
    public float fadeOutDuration = 1.0f; // Duración del fade out
    public AudioClip clickSound; // Clip de sonido para el clic
    private string rutaArchivo; // Ruta del archivo de guardado
    public bool OneTimeOnly = false;

    private void Awake()
    {
        // Inicializa la ruta del archivo
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

        if (clickSound == null)
        {
            Debug.LogWarning("No se asignó un clip de audio para el clic.");
        }
    }

    private void OnMouseDown()
    {
        if (clickSound != null)
        {
            AudioManager.instance.PlaySFX(clickSound); // Usa el AudioManager para reproducir el sonido
        }

        // Restaurar el cursor antes de cambiar de escena
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

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
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); // Resetear cursor antes del cambio

        if (musicSource != null)
        {
            StartCoroutine(FadeOutMusic());
        }

        if (animator != null)
        {
            animator.SetTrigger("StartTransition");
        }

        yield return new WaitForSeconds(animationDuration);

        SceneManager.LoadScene(scene);
    }

    private IEnumerator PlayAnimationAndChangeToTutorial()
    {
        if (musicSource != null)
        {
            StartCoroutine(FadeOutMusic());
        }

        if (animator != null)
        {
            animator.SetTrigger("StartTransition");
        }

        yield return new WaitForSeconds(animationDuration);

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
        musicSource.Stop();
    }

    private void check()
    {
        if (!File.Exists(rutaArchivo))
        {
            File.WriteAllText(rutaArchivo, "0");
            Debug.Log("Archivo creado con valor 0.");
        }

        string contenido = File.ReadAllText(rutaArchivo);
        Debug.Log("Valor actual del archivo: " + contenido);

        if (contenido == "1")
        {
            StartCoroutine(PlayAnimationAndChangeScene());
        }
        else if (contenido == "0")
        {
            File.WriteAllText(rutaArchivo, "1");
            StartCoroutine(PlayAnimationAndChangeToTutorial());
        }
        else
        {
            Debug.LogError("El archivo tiene un valor inesperado: " + contenido);
        }
    }
}

