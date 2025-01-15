using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagercounter : MonoBehaviour
{
    public int clickCount = 0;
    public int maxCount = 3;
    public string scene1;
    public string scene2;
    public string scene3;
    public Animator transitionAnimator;  // Referencia al Animator para la animación
    public AudioSource musicSource;      // Referencia a la fuente de música
    public float fadeOutDuration = 1f;   // Duración del fade out de la música
    public bool dontKillCertainNumOfEnemies = false;
    public Timer timer;                  // Referencia al script Timer
    private int numOfScene;

    private void Update()
    {
        if (timer.tiempoRestante == 0 && dontKillCertainNumOfEnemies && clickCount == 4)
        {
            Debug.Log("Jose");
            numOfScene = 0;
            StartCoroutine(TransitionToScene(scene1));
        }
        else if (clickCount == maxCount)
        {
            Debug.Log("Armario");
            numOfScene = 1;
            StartCoroutine(TransitionToScene(scene2));
        }
        else if (timer.tiempoRestante == 0 && clickCount < 4)
        {
            Debug.Log("OOOOOOOOOOOOOOO");
            numOfScene = 2;
            StartCoroutine(TransitionToScene(scene3));
        }
    }

    public void IncrementClickCount()
    {
        clickCount++;
        Debug.Log("Clics: " + clickCount); // Muestra el conteo en la consola
    }

    private IEnumerator TransitionToScene(string sceneName)
    {
        // Inicia la animación de transición
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("StartTransition");
        }

        // Fade out de la música
        if (musicSource != null)
        {
            float startVolume = musicSource.volume;
            float timeElapsed = 0f;

            while (timeElapsed < fadeOutDuration)
            {
                musicSource.volume = Mathf.Lerp(startVolume, 0f, timeElapsed / fadeOutDuration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            // Asegura que el volumen final sea 0
            musicSource.volume = 0f;
        }

        // Espera el tiempo de la animación antes de cambiar de escena
        if (transitionAnimator != null)
        {
            yield return new WaitForSeconds(transitionAnimator.GetCurrentAnimatorStateInfo(0).length);
        }

        // Cargar la nueva escena
        SceneManager.LoadScene(sceneName);
    }
}