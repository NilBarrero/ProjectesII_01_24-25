using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MinigameSelector : MonoBehaviour
{
    public string sceneName;
    public Button button;
    public GameObject pauseMenu;
    public Animator transitionAnimator;
    public AudioSource musicSource;
    public AudioSource buttonAudioSource;
    public AudioClip buttonClip;
    public float transitionTime = 1f;
    public float musicFadeDuration = 1f;

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
        if (button != null && button.image.color != Color.black)
        {
            if (!string.IsNullOrEmpty(sceneName))
            {
                Time.timeScale = 1f;

                if (pauseMenu != null && pauseMenu.activeSelf)
                {
                    pauseMenu.SetActive(false);
                }

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
