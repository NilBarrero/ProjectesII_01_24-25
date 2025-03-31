using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource sfxSource; // AudioSource para efectos de sonido

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
            Destroy(gameObject);
            return;
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
