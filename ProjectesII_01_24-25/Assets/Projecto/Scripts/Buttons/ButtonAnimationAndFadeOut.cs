using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class ButtonAnimationAndFadeOut : MonoBehaviour
{
    public Button button; 
    public Animator animator; 
    public AudioSource musicSource; 
    public float fadeOutDuration = 2f; 

    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        animator.SetTrigger("StartTransition");

        StartCoroutine(FadeOutMusic());
    }

    IEnumerator FadeOutMusic()
    {
        float startVolume = musicSource.volume;

        while (musicSource.volume > 0)
        {
            musicSource.volume -= startVolume * Time.deltaTime / fadeOutDuration;
            yield return null;
        }

        musicSource.Stop(); 
        musicSource.volume = startVolume; 
    }
}

