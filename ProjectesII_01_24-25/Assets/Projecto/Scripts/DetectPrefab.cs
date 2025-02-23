using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectPrefab : MonoBehaviour
{
    public string prefabName;
    public string prefabName2;
    public string scene;
    public string scene1;
    public MouseDrag mouseDrag;
    // Referencia al Animator que controla la animación
    public Animator animator;

    // Referencia al AudioSource de la música
    public AudioSource musicSource;
    public float fadeOutDuration = 2f; // Duración del fade out

    // Referencia al AudioSource para efectos de sonido
    public AudioSource sfxSource;

    private bool isTransitioning = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (mouseDrag == null)
        {
            Debug.Log("MouseDrag isn't inicialized properly");
        }
        // Verifica si el objeto detectado tiene el mismo nombre que el prefab esperado
        if (mouseDrag.isBeingHeld && !isTransitioning && (collision.gameObject.name == prefabName ))
        {
            Debug.Log(collision.gameObject.name);
            // Reproduce el efecto de sonido
            PlayDetectionSound();
            StartCoroutine(TransitionToScene(scene));
        }        if (mouseDrag.isBeingHeld && !isTransitioning && (collision.gameObject.name == prefabName2))
        {
            Debug.Log(collision.gameObject.name);

            // Reproduce el efecto de sonido
            PlayDetectionSound();
            StartCoroutine(TransitionToScene(scene1));
        }
    }

    private IEnumerator TransitionToScene(string scene)
    {
        isTransitioning = true; // Evita llamadas múltiples

        // Fade out de la música
        if (musicSource != null)
        {
            yield return StartCoroutine(FadeOutMusic());
        }

        // Animación de transición
        if (animator != null)
        {
            animator.SetTrigger("StartTransition"); // Activa la animación
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length); // Espera el tiempo de la animación
        }

        // Cambia de escena
        SceneManager.LoadScene(scene);
    }

    private IEnumerator FadeOutMusic()
    {
        float startVolume = musicSource.volume;

        // Reduce el volumen de la música durante un tiempo
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

    private void PlayDetectionSound()
    {
        if (sfxSource != null)
        {
            sfxSource.Play();
        }
    }
}
