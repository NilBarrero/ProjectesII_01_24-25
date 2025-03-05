using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MinigameSelector : MonoBehaviour
{
    public string sceneName;
    public Button button;
    public GameObject pauseMenu;
    public Animator transitionAnimator; // Animator para la animación de transición
    public AudioSource musicSource; // Fuente de audio de la música
    public AudioSource buttonAudioSource; // Fuente de audio para el sonido del botón
    public AudioClip buttonClip; // Clip de sonido para el botón
    public float transitionTime = 1f; // Tiempo de transición
    public float musicFadeDuration = 1f; // Duración del fade-out de la música

    private void Start()
    {
        if (button != null)
        {
            button.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogWarning("No se asignó un botón en el inspector.");
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

            // Reproducir sonido del botón
            if (buttonAudioSource != null && buttonClip != null)
            {
                buttonAudioSource.PlayOneShot(buttonClip);
            }

            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("El nombre de la escena no está configurado.");
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

        // Esperar el mayor tiempo entre la animación y el fade-out
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

