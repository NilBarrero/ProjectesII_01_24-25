using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class ButtonAnimationAndFadeOut : MonoBehaviour
{
    public Button button; // El botón al que le haremos click
    public Animator animator; // El Animator que controla la animación
    public AudioSource musicSource; // El AudioSource de la música
    public float fadeOutDuration = 2f; // Duración del fade out de la música

    void Start()
    {
        // Añadir el listener para el botón
        button.onClick.AddListener(OnButtonClick);
    }

    // Este método se llama cuando se hace click en el botón
    void OnButtonClick()
    {
        // Ejecutar la animación
        animator.SetTrigger("StartTransition");

        // Iniciar el fade out de la música
        StartCoroutine(FadeOutMusic());
    }

    // Coroutine para hacer fade out de la música
    IEnumerator FadeOutMusic()
    {
        float startVolume = musicSource.volume;

        // Desaparecer la música poco a poco
        while (musicSource.volume > 0)
        {
            musicSource.volume -= startVolume * Time.deltaTime / fadeOutDuration;
            yield return null;
        }

        musicSource.Stop(); // Detener la música completamente al final
        musicSource.volume = startVolume; // Restaurar el volumen original para futuras reproducciones
    }
}
