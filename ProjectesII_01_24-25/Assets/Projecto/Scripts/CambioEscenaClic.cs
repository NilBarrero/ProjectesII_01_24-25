using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaClic : MonoBehaviour
{
    public int clicksRequired = 5; // Número de clics necesarios para cambiar la escena
    public string sceneToLoad;
    public Animator transitionAnimator; // Animador para la transición
    public AudioSource musicSource; // AudioSource de la música
    public float fadeOutDuration = 0f; // Tiempo del fade out de la música

    private int clickCount = 0; // Contador de clics
    private bool isTransitioning = false;

    void OnMouseDown()
    {
        if (isTransitioning) return; // Evita múltiples activaciones

        clickCount++; // Aumenta el contador al hacer clic

        if (clickCount >= clicksRequired)
        {
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        isTransitioning = true;

        // Inicia la animación de transición
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("StartTransition");
        }

        // Fade out de la música
        if (musicSource != null)
        {
            float startVolume = musicSource.volume;
            float t = 0;

            while (t < fadeOutDuration)
            {
                t += Time.deltaTime;
                musicSource.volume = Mathf.Lerp(startVolume, 0, t / fadeOutDuration);
                yield return null;
            }

            musicSource.volume = 0;
            musicSource.Stop();
        }

        // Espera un poco para que termine la animación antes de cambiar la escena
        yield return new WaitForSeconds(1.5f);

        // Carga la nueva escena
        SceneManager.LoadScene(sceneToLoad);
    }
}
