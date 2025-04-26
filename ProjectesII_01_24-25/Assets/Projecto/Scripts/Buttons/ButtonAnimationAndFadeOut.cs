using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class ButtonAnimationAndFadeOut : MonoBehaviour
{
    public Button button; // The button to be clicked
    public Animator animator; // The Animator controlling the animation
    public AudioSource musicSource; // The AudioSource for the music
    public float fadeOutDuration = 2f; // Duration of the music fade-out

    void Start()
    {
        // Add the listener to the button
        button.onClick.AddListener(OnButtonClick);
    }

    // This method is called when the button is clicked
    void OnButtonClick()
    {
        // Play the animation
        animator.SetTrigger("StartTransition");

        // Start fading out the music
        StartCoroutine(FadeOutMusic());
    }

    // Coroutine to fade out the music
    IEnumerator FadeOutMusic()
    {
        float startVolume = musicSource.volume;

        // Gradually decrease the music volume
        while (musicSource.volume > 0)
        {
            musicSource.volume -= startVolume * Time.deltaTime / fadeOutDuration;
            yield return null;
        }

        musicSource.Stop(); // Completely stop the music at the end
        musicSource.volume = startVolume; // Restore the original volume for future plays
    }
}

