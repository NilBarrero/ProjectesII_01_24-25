using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaClic : MonoBehaviour
{
    public int clicksRequired = 1; // N�mero inicial de clics necesarios (1)
    public string sceneToLoad;
    public Animator transitionAnimator; // Animador para la transici�n
    public AudioSource musicSource; // AudioSource de la m�sica
    public float fadeOutDuration = 0f; // Duraci�n del fade out de la m�sica
    public PauseMenu pauseMenu; // Referencia al script del men� de pausa

    private int clickCount = 0; // Contador de clics
    private bool isTransitioning = false;
    private bool menuAbiertoAlMenosUnaVez = false; // Indica si el men� se abri� en alg�n momento

    void OnMouseDown()
    {
        if (isTransitioning) return; // Evita m�ltiples activaciones


        clickCount++;

        if (clickCount >= clicksRequired)
        {
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        isTransitioning = true;

        // Inicia la animaci�n de transici�n
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("StartTransition");
        }

        // Realiza el fade out de la m�sica, si se ha asignado un AudioSource
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

        // Espera un poco para que termine la animaci�n antes de cambiar la escena
        yield return new WaitForSeconds(1.5f);

        // Carga la nueva escena
        SceneManager.LoadScene(sceneToLoad);
    }
}

