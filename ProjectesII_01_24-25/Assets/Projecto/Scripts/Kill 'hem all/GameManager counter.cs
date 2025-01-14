using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagercounter : MonoBehaviour
{
    public int clickCount = 0;
    public int maxCount = 4;
    public string scene;
    public Animator transitionAnimator;  // Referencia al Animator para la animación
    public AudioSource musicSource;      // Referencia a la fuente de música
    public float fadeOutDuration = 1f;   // Duración del fade out de la música

    private void Update()
    {
        if (clickCount == maxCount)
        {
            StartCoroutine(TransitionToScene());
        }
    }

    public void IncrementClickCount()
    {
        clickCount++;
        Debug.Log("Clics: " + clickCount); // Muestra el conteo en la consola
    }

    private IEnumerator TransitionToScene()
    {
        // Inicia la animación de transición
        transitionAnimator.SetTrigger("StartTransition"); // Asegúrate de tener un trigger llamado "StartTransition" en tu Animator

        // Fade out de la música
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

        // Espera el tiempo de la animación antes de cambiar de escena
        yield return new WaitForSeconds(transitionAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Cargar la nueva escena
        SceneManager.LoadScene(scene);
    }
}
