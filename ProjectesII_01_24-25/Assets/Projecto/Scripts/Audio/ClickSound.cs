using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public AudioClip clickSound; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (audioSource && clickSound)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
