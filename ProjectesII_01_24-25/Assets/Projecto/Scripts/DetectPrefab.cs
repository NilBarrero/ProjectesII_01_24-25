using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectPrefab : MonoBehaviour
{
    public string prefabName;
    public string prefabName2;
    public string scene;

    // Referencia al Animator que controla la animaci�n
    public Animator animator;

    // Referencia al AudioSource de la m�sica
    public AudioSource musicSource;
    public float fadeOutDuration = 2f; // Duraci�n del fade out

    private bool isTransitioning = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto detectado tiene el mismo nombre que el prefab esperado
        if (!isTransitioning && (collision.gameObject.name == prefabName || collision.gameObject.name == prefabName2))
        {
            StartCoroutine(TransitionToScene());
        }
    }

    private IEnumerator TransitionToScene()
    {
        isTransitioning = true; // Evita llamadas m�ltiples

        // Fade out de la m�sica
        if (musicSource != null)
        {
            yield return StartCoroutine(FadeOutMusic());
        }

        // Animaci�n de transici�n
        if (animator != null)
        {
            animator.SetTrigger("StartTransition"); // Activa la animaci�n
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length); // Espera el tiempo de la animaci�n
        }

        // Cambia de escena
        SceneManager.LoadScene(scene);
    }

    private IEnumerator FadeOutMusic()
    {
        float startVolume = musicSource.volume;

        // Reduce el volumen de la m�sica durante un tiempo
        float timeElapsed = 0f;
        while (timeElapsed < fadeOutDuration)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0f, timeElapsed / fadeOutDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Asegura que el volumen llegue a 0
        musicSource.volume = 0f;
    }
}


