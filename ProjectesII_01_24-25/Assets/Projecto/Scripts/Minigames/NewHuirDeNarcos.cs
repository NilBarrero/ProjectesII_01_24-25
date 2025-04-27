using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class NewHuirDeNarcosLogic : MonoBehaviour
{
    // Reference to the Animator that controls the animation
    public UnityEngine.UI.Slider progressBar;
    public Animator animator;
    public string scene;
    // Reference to the AudioSource for music
    public AudioSource musicSource;
    // Reference to the AudioSource for sound effects
    public AudioSource sfxSource;
    private bool isTransitioning = false;
    public float fadeOutDuration = 2f; // Fade out duration
    public Pressed pressed;
    public int initcounter = 0;
    public int maxCounter = 60;
    private bool isClickReleased = true;

    public float progress = 0;

    void Start()
    {
    }

    void Update()
    {
        // Check if the max counter has been reached and start the transition
        if (initcounter == maxCounter)
        {
            Debug.Log("Init counter == Max Counter");
            StartCoroutine(TransitionToScene(scene));
        }
        else
        {
            // Detect if the button has been pressed
            if (Input.GetMouseButtonDown(0) && isClickReleased)
            {
                // If the click was released before, increase the counter
                initcounter++;
                isClickReleased = false; // Mark that the click is being held
            }

            // Detect if the click has been released
            if (Input.GetMouseButtonUp(0))
            {
                isClickReleased = true; // The click was released, we can count again
            }
            if (progressBar != null)
            {
                // Calculate progress as a percentage
                progress = (float)initcounter / (float)maxCounter;
                progressBar.value = progress; // Update the progress bar
            }
        }
    }

    private IEnumerator TransitionToScene(string scene)
    {
        isTransitioning = true; // Prevent multiple calls

        // Fade out the music
        if (musicSource != null)
        {
            yield return StartCoroutine(FadeOutMusic());
        }

        // Transition animation
        if (animator != null)
        {
            animator.SetTrigger("StartTransition"); // Trigger the animation
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length); // Wait for the animation to finish
        }

        // Change scene
        SceneManager.LoadScene(scene);
    }

    private IEnumerator FadeOutMusic()
    {
        float startVolume = musicSource.volume;

        // Gradually reduce the volume of the music
        float timeElapsed = 0f;
        while (timeElapsed < fadeOutDuration)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0f, timeElapsed / fadeOutDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the volume reaches 0
        musicSource.volume = 0f;
    }

    private void PlayDetectionSound()
    {
        if (sfxSource != null)
        {
            sfxSource.Play();
        }
    }
}
