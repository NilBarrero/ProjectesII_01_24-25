using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnClick : MonoBehaviour
{
    public int clicksRequired = 1; // Initial number of clicks required (1)
    public string sceneToLoad;
    public Animator transitionAnimator; // Animator for the transition
    public AudioSource musicSource; // AudioSource for the music
    public float fadeOutDuration = 0f; // Duration of the music fade-out
    public PauseMenu pauseMenu; // Reference to the pause menu script

    private int clickCount = 0; // Click counter
    private bool isTransitioning = false;
    private bool menuOpenedAtLeastOnce = false; // Indicates if the menu was opened at least once

    void OnMouseDown()
    {
        if (isTransitioning) return; // Prevent multiple activations

        clickCount++;

        if (clickCount >= clicksRequired)
        {
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        isTransitioning = true;

        // Start the transition animation
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("StartTransition");
        }

        // Perform the music fade-out if an AudioSource is assigned
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

        // Wait a bit for the animation to finish before changing the scene
        yield return new WaitForSeconds(1.5f);

        // Load the new scene
        SceneManager.LoadScene(sceneToLoad);
    }
}


