using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnClick : MonoBehaviour
{
    public int clicksRequired = 1; 
    public string sceneToLoad;
    public Animator transitionAnimator; 
    public AudioSource musicSource; 
    public float fadeOutDuration = 0f; 
    public PauseMenu pauseMenu; 

    private int clickCount = 0; 
    private bool isTransitioning = false;
    private bool menuOpenedAtLeastOnce = false; 

    void OnMouseDown()
    {
        if (isTransitioning) return; 

        clickCount++;

        if (clickCount >= clicksRequired)
        {
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        isTransitioning = true;

        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("StartTransition");
        }

        if (musicSource != null)
        {
            float startVolume = musicSource.volume;
            float t = 0;

            while (t < fadeOutDuration)
            {
                t += Time.deltaTime;
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


