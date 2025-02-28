using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class NewHuirDeNarcosLogic : MonoBehaviour
{
    // Referencia al Animator que controla la animaci�n
    public UnityEngine.UI.Slider progressBar;
    public Animator animator;
    public string scene;
    // Referencia al AudioSource de la m�sica
    public AudioSource musicSource;
    // Referencia al AudioSource para efectos de sonido
    public AudioSource sfxSource;
    private bool isTransitioning = false;
    public float fadeOutDuration = 2f; // Duraci�n del fade out
    public Pressed pressed;
    public int initcounter = 0;
    public int maxCounter = 60;
    private bool isClickReleased = true;


    public float progress = 0;

    void Start()
    {
    }

    void Update()
    {
        // Verificar si se ha alcanzado el contador m�ximo y hacer la transici�n
        if (initcounter == maxCounter)
        {
            Debug.Log("Init counter == Max Counter");
            StartCoroutine(TransitionToScene(scene));
        }
        else
        {
            // Detectar si se presion� el bot�n
            if (Input.GetMouseButtonDown(0) && isClickReleased)
            {
                // Si el clic fue levantado previamente, aumentamos el contador
                initcounter++;
                isClickReleased = false; // Marcamos que el clic est� siendo mantenido
            }

            // Detectamos si el clic fue liberado
            if (Input.GetMouseButtonUp(0))
            {
                isClickReleased = true; // El clic fue liberado, se puede contar nuevamente
            }
            if (progressBar != null)
            {
                // Calcula el progreso como un porcentaje
                progress = (float)initcounter / (float)maxCounter;
                progressBar.value = progress; // Actualiza el valor de la barra
            }
        }
    }

    private IEnumerator TransitionToScene(string scene)
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

    private void PlayDetectionSound()
    {
        if (sfxSource != null)
        {
            sfxSource.Play();
        }
    }
}