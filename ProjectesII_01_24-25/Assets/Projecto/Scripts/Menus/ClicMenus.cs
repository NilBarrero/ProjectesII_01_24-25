using UnityEngine;
using UnityEngine.UI;

public class ClicMenus : MonoBehaviour
{
    public Button button; // Reference to the UI button
    public AudioClip sound; // Sound to be played
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component or add one if it doesn't exist
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Configure the AudioSource
        audioSource.playOnAwake = false;

        // Assign the sound
        audioSource.clip = sound;

        // Link the button's click event
        if (button != null)
        {
            button.onClick.AddListener(PlaySound);
        }
        else
        {
            Debug.LogError("Button not assigned in the inspector.");
        }
    }

    // Method to play the sound
    void PlaySound()
    {
        if (sound != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Sound not assigned in the inspector.");
        }
    }
}
