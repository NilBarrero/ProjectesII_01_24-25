using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public AudioClip clickSound; // The sound that will play on click
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component from the object (make sure the object has an AudioSource)
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        // Play the audio clip when the object is clicked
        if (audioSource && clickSound)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
