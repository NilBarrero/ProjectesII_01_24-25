using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource sfxSource; // AudioSource for sound effects
    private float sfxVolume = 1.0f; // Volume of sound effects

    private void Awake()
    {
        // Ensure there is only one AudioManager in the scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    // Plays a sound effect
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip, sfxVolume);
    }

    // Sets the SFX volume
    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        sfxSource.volume = sfxVolume;
    }

    // Method to get the current SFX volume
    public float GetSFXVolume()
    {
        return sfxVolume;
    }
}

