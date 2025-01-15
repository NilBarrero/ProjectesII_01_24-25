using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public AudioClip clickSound; // El sonido que se reproducir� al hacer clic
    private AudioSource audioSource;

    void Start()
    {
        // Obtiene el AudioSource del objeto (aseg�rate de que el objeto tenga un AudioSource)
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        // Reproduce el clip de audio cuando el objeto es clickeado
        if (audioSource && clickSound)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}