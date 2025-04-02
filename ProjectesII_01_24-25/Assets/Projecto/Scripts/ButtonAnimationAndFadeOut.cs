using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class ButtonAnimationAndFadeOut : MonoBehaviour
{
    public Button button; // El bot�n al que le haremos click
    public Animator animator; // El Animator que controla la animaci�n
    public AudioSource musicSource; // El AudioSource de la m�sica
    public float fadeOutDuration = 2f; // Duraci�n del fade out de la m�sica

    void Start()
    {
        // A�adir el listener para el bot�n
        button.onClick.AddListener(OnButtonClick);
    }

    // Este m�todo se llama cuando se hace click en el bot�n
    void OnButtonClick()
    {
        // Ejecutar la animaci�n
        animator.SetTrigger("StartTransition");

        // Iniciar el fade out de la m�sica
        StartCoroutine(FadeOutMusic());
    }

    // Coroutine para hacer fade out de la m�sica
    IEnumerator FadeOutMusic()
    {
        float startVolume = musicSource.volume;

        // Desaparecer la m�sica poco a poco
        while (musicSource.volume > 0)
        {
            musicSource.volume -= startVolume * Time.deltaTime / fadeOutDuration;
            yield return null;
        }

        musicSource.Stop(); // Detener la m�sica completamente al final
        musicSource.volume = startVolume; // Restaurar el volumen original para futuras reproducciones
    }
}
