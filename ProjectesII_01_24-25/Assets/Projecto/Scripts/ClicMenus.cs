using UnityEngine;
using UnityEngine.UI;

public class ClicMenus : MonoBehaviour
{
    public Button button; // Referencia al botón UI
    public AudioClip sound; // Sonido que se reproducirá
    private AudioSource audioSource;

    void Start()
    {
        // Obtener el componente AudioSource o agregar uno si no existe
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Configurar el AudioSource
        audioSource.playOnAwake = false;

        // Asignar el sonido
        audioSource.clip = sound;

        // Vincular el evento de clic del botón
        if (button != null)
        {
            button.onClick.AddListener(PlaySound);
        }
        else
        {
            Debug.LogError("Botón no asignado en el inspector.");
        }
    }

    // Método para reproducir el sonido
    void PlaySound()
    {
        if (sound != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Sonido no asignado en el inspector.");
        }
    }
}
