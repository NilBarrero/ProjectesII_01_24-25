using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public string scene; // Nombre de la escena a cargar
    public Animator animator; // Asigna el Animator que controla la animación de transición
    public float animationDuration = 1.0f; // Duración de la animación (ajústala según tu animación)
    public AudioSource musicSource; // Fuente de audio para la música
    public float fadeOutDuration = 1.0f; // Duración del fade out en segundos

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
    }

    private void OnMouseDown()
    {
        StartCoroutine(PlayAnimationAndChangeScene());
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
}


