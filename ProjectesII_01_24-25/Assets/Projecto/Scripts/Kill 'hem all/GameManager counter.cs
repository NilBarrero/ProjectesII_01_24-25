using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagercounter : MonoBehaviour
{
    public int clickCount = 0;
    public int maxCount = 3;
    public string scene;
    public Animator transitionAnimator;  // Referencia al Animator para la animaci�n
    public AudioSource musicSource;      // Referencia a la fuente de m�sica
    public float fadeOutDuration = 1f;   // Duraci�n del fade out de la m�sica

    private void Update()
    {
        if (dontKillCertainNumOfEnemies && clickCount >= numOfMinNumber && clickCount < maxCount && timer.tiempoRestante == 0)
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
        // Inicia la animaci�n de transici�n
        transitionAnimator.SetTrigger("StartTransition"); // Aseg�rate de tener un trigger llamado "StartTransition" en tu Animator

        // Fade out de la m�sica
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

        // Espera el tiempo de la animaci�n antes de cambiar de escena
        yield return new WaitForSeconds(transitionAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Cargar la nueva escena
        SceneManager.LoadScene(scene);
    }
}
