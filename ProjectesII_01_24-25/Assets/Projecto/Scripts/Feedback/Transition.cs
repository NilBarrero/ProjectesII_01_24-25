using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Transition : MonoBehaviour
{
    public string scene; // Name of the scene to load
    public string tutorial; // Name of the tutorial scene to load
    public Animator animator; // Animator that controls the transition animation
    public float animationDuration = 1.0f; // Duration of the animation
    public AudioSource musicSource; // Audio source for background music
    public float fadeOutDuration = 1.0f; // Duration of the fade-out
    public AudioClip clickSound; // Audio clip for the click
    private string rutaArchivo; // Path to the save file
    public bool OneTimeOnly = false;

    private void Awake()
    {
        // Initialize the path to the save file
        rutaArchivo = Application.persistentDataPath + "/EntryLog.txt";
    }

    private void Start()
    {
        Debug.Log("Path to EntryLog.txt file: " + rutaArchivo);
        if (animator == null)
        {
            Debug.LogError("Animator was not assigned. Please assign one in the Inspector.");
        }

        if (musicSource == null)
        {
            Debug.LogWarning("No audio source assigned. Fade-out will not be performed.");
        }

        if (clickSound == null)
        {
            Debug.LogWarning("No click audio clip assigned.");
        }
    }

    private void OnMouseDown()
    {
        if (clickSound != null)
        {
            AudioManager.instance.PlaySFX(clickSound); // Use AudioManager to play the sound
        }

        // Reset the cursor before changing the scene
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
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); // Reset cursor before changing

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
            Debug.Log("File created with value 0.");
        }

        string contenido = File.ReadAllText(rutaArchivo);
        Debug.Log("Current file value: " + contenido);

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
            Debug.LogError("The file has an unexpected value: " + contenido);
        }
    }
}
