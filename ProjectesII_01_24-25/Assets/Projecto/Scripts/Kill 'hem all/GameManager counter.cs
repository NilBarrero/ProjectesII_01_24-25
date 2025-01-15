using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagercounter : MonoBehaviour
{
    public int clickCount = 0;
    public int maxCount = 3;
    public string scene1;
    public string scene2;
    public string scene3;
    public Animator transitionAnimator;  // Referencia al Animator para la animaci�n
    public AudioSource musicSource;      // Referencia a la fuente de m�sica
    public float fadeOutDuration = 1f;   // Duraci�n del fade out de la m�sica
    public bool dontKillCertainNumOfEnemies = false;
    // public int numOfMinNumber;
    public Timer timer;
    private int numOfScene;

    private void Update()

    {
        if (timer.tiempoRestante == 0 && dontKillCertainNumOfEnemies && clickCount == 4)
        {

            Debug.Log("Jose");
            numOfScene = 0;
            StartCoroutine(TransitionToScene());
        }

        else if (timer.tiempoRestante == 0 && clickCount == maxCount)
        {
            Debug.Log("Armario");
            numOfScene = 1;
            StartCoroutine(TransitionToScene());
        }
        else if (timer.tiempoRestante == 0 && clickCount < 4)
        {
            Debug.Log("OOOOOOOOOOOOOOO");
            numOfScene = 2;
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

        if (numOfScene == 0)
        // Cargar la nueva escena
        {
            SceneManager.LoadScene(scene1);
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAa");
        }
        if (numOfScene == 1)
            SceneManager.LoadScene(scene2);
        if (numOfScene == 2)
            SceneManager.LoadScene(scene3);

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



    }
}