using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MinigameSelector : MonoBehaviour
{
    public string sceneName;
    public Button button;
    public GameObject pauseMenu;
    public Animator transitionAnimator; // Animator for the transition animation
    public AudioSource musicSource; // Audio source for background music
    public AudioSource buttonAudioSource; // Audio source for button sound
    public AudioClip buttonClip; // Sound clip for the button
    public float transitionTime = 1f; // Transition duration
    public float musicFadeDuration = 1f; // Music fade-out duration

    private void Start()
    {
        if (button != null)
        {
            button.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogWarning("Button not assigned in the inspector.");
        }
    }

    public void ChangeScene()
    {
        // Check if the button color is not black
        if (button != null && button.image.color != Color.black)
        {
            if (!string.IsNullOrEmpty(sceneName))
            {
                Time.timeScale = 1f;

                if (pauseMenu != null && pauseMenu.activeSelf)
                {
                    pauseMenu.SetActive(false);
                }

                // Play button sound
                if (buttonAudioSource != null && buttonClip != null)
                {
                    buttonAudioSource.PlayOneShot(buttonClip);
                }

                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogError("Scene name is not set.");
            }
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

        // Wait for the longer of the transition or fade-out times
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
