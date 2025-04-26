using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOutMusic : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource; // The AudioSource that holds the music.
    [SerializeField] private float fadeDuration = 5f; // Duration of the fade-in and fade-out in seconds.
    private float targetVolume; // The final volume to reach.

    private void Start()
    {
        // Make sure an AudioSource is assigned.
        if (musicSource == null)
        {
            Debug.LogError("No AudioSource assigned to the FadeInOutMusic script.");
            return;
        }

        // Save the initial volume of the AudioSource and set it to 0.
        targetVolume = musicSource.volume;
        musicSource.volume = 0f;

        // Start the music if it’s not already playing.
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }

        // Start the fade-in process.
        StartCoroutine(FadeIn());
    }

    private System.Collections.IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // Gradually increase the volume.
            musicSource.volume = Mathf.Lerp(0f, targetVolume, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;

            // Wait until the next frame.
            yield return null;
        }

        // Make sure the final volume is exactly the target volume.
        musicSource.volume = targetVolume;
    }

    public void TriggerSceneChange(string sceneName)
    {
        // Start the fade-out before changing scenes.
        StartCoroutine(FadeOutAndChangeScene(sceneName));
    }

    private System.Collections.IEnumerator FadeOutAndChangeScene(string sceneName)
    {
        float elapsedTime = 0f;
        float startVolume = musicSource.volume;

        while (elapsedTime < fadeDuration)
        {
            // Gradually decrease the volume.
            musicSource.volume = Mathf.Lerp(startVolume, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;

            // Wait until the next frame.
            yield return null;
        }

        // Make sure the volume is exactly 0.
        musicSource.volume = 0f;

        // Switch to the new scene.
        SceneManager.LoadScene(sceneName);
    }
}

