using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnClick : MonoBehaviour
{
    public int clicksRequired = 1;
    public string sceneToLoad;
    public Animator transitionAnimator;
    public AudioSource musicSource;
    public float fadeOutDuration = 0f;

    private int clickCount = 0;
    private bool isTransitioning = false;

    void OnMouseDown()
    {
        if (isTransitioning || ++clickCount < clicksRequired) return;
        StartCoroutine(ChangeScene());
    }

    private System.Collections.IEnumerator ChangeScene()
    {
        isTransitioning = true;

        transitionAnimator?.SetTrigger("StartTransition");

        if (musicSource)
        {
            float startVolume = musicSource.volume;
            for (float t = 0; t < fadeOutDuration; t += Time.deltaTime)
            {
                musicSource.volume = Mathf.Lerp(startVolume, 0, t / fadeOutDuration);
                yield return null;
            }
            musicSource.volume = 0;
            musicSource.Stop();
        }

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneToLoad);
    }
}



