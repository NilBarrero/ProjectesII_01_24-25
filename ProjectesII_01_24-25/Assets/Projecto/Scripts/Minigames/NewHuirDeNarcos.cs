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
    public float fadeOutDuration = 2f; 
    public Pressed pressed;
    public int initcounter = 0;
    public int maxCounter = 60;
    private bool isClickReleased = true;

    public float progress = 0;

    void Update()
    {
        if (initcounter == maxCounter)
        {
            Debug.Log("Init counter == Max Counter");
            StartCoroutine(TransitionToScene(scene));
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && isClickReleased)
            {
                initcounter++;
                isClickReleased = false; 
            }

            if (Input.GetMouseButtonUp(0))
            {
                isClickReleased = true; 
            }
            if (progressBar != null)
            {
                progress = (float)initcounter / (float)maxCounter;
                progressBar.value = progress; 
            }
        }
    }

    private IEnumerator TransitionToScene(string scene)
    {
        isTransitioning = true; 

        if (musicSource != null)
        {
            yield return StartCoroutine(FadeOutMusic());
        }

        if (animator != null)
        {
            animator.SetTrigger("StartTransition"); 
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length); 
        }

        SceneManager.LoadScene(scene);
    }

    private IEnumerator FadeOutMusic()
    {
        float startVolume = musicSource.volume;

        float timeElapsed = 0f;
        while (timeElapsed < fadeOutDuration)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0f, timeElapsed / fadeOutDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

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
