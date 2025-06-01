using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOutMusic : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private float fadeDuration = 5f;
    private float targetVolume;

    private void Start()
    {
        if (!musicSource)
        {
            Debug.LogError("No AudioSource assigned.");
            return;
        }

        targetVolume = musicSource.volume;
        musicSource.volume = 0f;
        if (!musicSource.isPlaying) musicSource.Play();
        StartCoroutine(FadeVolume(0f, targetVolume));
    }

    public void TriggerSceneChange(string sceneName) =>
        StartCoroutine(FadeOutAndLoad(sceneName));

    private System.Collections.IEnumerator FadeOutAndLoad(string sceneName)
    {
        yield return StartCoroutine(FadeVolume(musicSource.volume, 0f));
        SceneManager.LoadScene(sceneName);
    }

    private System.Collections.IEnumerator FadeVolume(float from, float to)
    {
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(from, to, t / fadeDuration);
            yield return null;
        }
        musicSource.volume = to;
    }
}


