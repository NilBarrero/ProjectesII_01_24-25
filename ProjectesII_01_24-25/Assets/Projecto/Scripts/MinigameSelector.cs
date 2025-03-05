using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MinigameSelector : MonoBehaviour
{
    public string sceneName;
    public Button button;
    public GameObject pauseMenu;
    public Animator transitionAnimator; // Animator para la animaci�n de transici�n
    public AudioSource musicSource; // Fuente de audio de la m�sica
    public AudioSource buttonAudioSource; // Fuente de audio para el sonido del bot�n
    public AudioClip buttonClip; // Clip de sonido para el bot�n
    public float transitionTime = 1f; // Tiempo de transici�n
    public float musicFadeDuration = 1f; // Duraci�n del fade-out de la m�sica

    private void Start()
    {
        if (button != null)
        {
            button.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogWarning("No se asign� un bot�n en el inspector.");
        }
    }

    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            Time.timeScale = 1f;

            if (pauseMenu != null && pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
            }

            // Reproducir sonido del bot�n
            if (buttonAudioSource != null && buttonClip != null)
            {
                buttonAudioSource.PlayOneShot(buttonClip);
            }

            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("El nombre de la escena no est� configurado.");
        }
    }

    private IEnumerator LoadSceneWithTransition()
    {
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("StartTransition");
        }

        if (musicSource != null)
        {
            StartCoroutine(FadeOutMusic());
        }

        // Esperar el mayor tiempo entre la animaci�n y el fade-out
        float waitTime = Mathf.Max(transitionTime, musicFadeDuration);
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator FadeOutMusic()
    {
        float startVolume = musicSource.volume;
        float elapsedTime = 0f;

        while (elapsedTime < musicFadeDuration)
        {
            elapsedTime += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(startVolume, 0f, elapsedTime / musicFadeDuration);
            yield return null;
        }

        musicSource.volume = 0f;
        musicSource.Stop();
    }
}

