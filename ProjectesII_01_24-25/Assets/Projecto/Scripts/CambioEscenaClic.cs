using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaClic : MonoBehaviour
{
    public int clicksRequired = 1; // Número inicial de clics necesarios (1)
    public string sceneToLoad;
    public Animator transitionAnimator; // Animador para la transición
    public AudioSource musicSource; // AudioSource de la música
    public float fadeOutDuration = 0f; // Duración del fade out de la música
    public PauseMenu pauseMenu; // Referencia al script del menú de pausa

    private int clickCount = 0; // Contador de clics
    private bool isTransitioning = false;
    private bool menuAbiertoAlMenosUnaVez = false; // Indica si el menú se abrió en algún momento

    void OnMouseDown()
    {
        if (isTransitioning) return; // Evita múltiples activaciones


        clickCount++;

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

        // Realiza el fade out de la música, si se ha asignado un AudioSource
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

