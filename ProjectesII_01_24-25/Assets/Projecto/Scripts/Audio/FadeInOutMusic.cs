using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOutMusic : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource; 
    [SerializeField] private float fadeDuration = 5f; 
    private float targetVolume; 

    private void Start()
    {
        if (musicSource == null)
        {
            Debug.LogError("No AudioSource assigned to the FadeInOutMusic script.");
            return;
        }

        targetVolume = musicSource.volume;
        musicSource.volume = 0f;

        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }

        StartCoroutine(FadeIn());
    }

    private System.Collections.IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            musicSource.volume = Mathf.Lerp(0f, targetVolume, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        musicSource.volume = targetVolume;
    }

    public void TriggerSceneChange(string sceneName)
    {
        StartCoroutine(FadeOutAndChangeScene(sceneName));
    }

    private System.Collections.IEnumerator FadeOutAndChangeScene(string sceneName)
    {
        float elapsedTime = 0f;
        float startVolume = musicSource.volume;

        while (elapsedTime < fadeDuration)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        musicSource.volume = 0f;

        SceneManager.LoadScene(sceneName);
    }
}

