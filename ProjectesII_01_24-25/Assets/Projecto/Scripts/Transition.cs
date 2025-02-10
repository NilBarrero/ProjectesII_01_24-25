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
    public string rutaArchivo = "Assets/Projecto/TXT/EntryLog.txt";
    public bool OneTimeOnly = false;

    private AudioSource audioSource; // Fuente de audio para reproducir el efecto de clic

    private void Start()
    {
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
        else if (!OneTimeOnly)
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
        if (File.Exists(rutaArchivo))
        {
            // Leer todo el contenido del archivo
            string contenido = File.ReadAllText(rutaArchivo);

            // Si el archivo tiene un "0", significa que es la primera vez que el jugador juega
            if (contenido.Contains("1"))
            {
                StartCoroutine(PlayAnimationAndChangeScene());
            }
            else if (contenido.Contains("0"))
            {
                string nuevoContenido = contenido.Replace("0", "1");

                // Guardar el archivo con el nuevo contenido
                File.WriteAllText(rutaArchivo, nuevoContenido);
                StartCoroutine(PlayAnimationAndChangeToTutorial());

            }
        }
        else
        {
            // Si el archivo no existe, lo creamos e inicializamos con "0"
            File.WriteAllText(rutaArchivo, "0");
            Debug.Log("Archivo creado y valor inicializado a 0.");
        }
    }
}



