using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource sfxSource; // AudioSource para los efectos de sonido
    private float sfxVolume = 1.0f; // Volumen de los efectos de sonido

    private void Awake()
    {
        // Asegurar que solo haya un AudioManager en la escena
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantener al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Evitar duplicados
        }
    }

    // Reproduce un efecto de sonido
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip, sfxVolume);
    }

    // Establece el volumen de los SFX
    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        sfxSource.volume = sfxVolume;
    }

    // Método para obtener el volumen actual de los SFX
    public float GetSFXVolume()
    {
        return sfxVolume;
    }
}

