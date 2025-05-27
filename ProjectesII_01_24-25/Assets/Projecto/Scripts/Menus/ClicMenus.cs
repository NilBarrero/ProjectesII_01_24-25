using UnityEngine;
using UnityEngine.UI;

public class ClicMenus : MonoBehaviour
{
    public Button button;
    public AudioClip sound;
    private AudioSource audioSource;

    void Start()
    {

        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;

        audioSource.clip = sound;

        if (button != null)
        {
            button.onClick.AddListener(PlaySound);
        }
        else
        {
            Debug.LogError("Button not assigned in the inspector.");
        }
    }

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
