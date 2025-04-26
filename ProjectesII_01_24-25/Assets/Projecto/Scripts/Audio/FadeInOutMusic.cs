using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOutMusic : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource; // El AudioSource que contiene la música.
    [SerializeField] private float fadeDuration = 5f; // Duración del fade-in y fade-out en segundos.
    private float targetVolume; // El volumen final al que llegará.

    private void Start()
    {
        // Asegurarse de que hay un AudioSource asignado.
        if (musicSource == null)
        {
            Debug.LogError("No se ha asignado un AudioSource al script FadeInOutMusic.");
            return;
        }

        // Guardar el volumen inicial del AudioSource y configurarlo a 0.
        targetVolume = musicSource.volume;
        musicSource.volume = 0f;

        // Iniciar la música si no está ya reproduciéndose.
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }

        // Iniciar el proceso de fade-in.
        StartCoroutine(FadeIn());
    }

    private System.Collections.IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // Incrementar el volumen gradualmente.
            musicSource.volume = Mathf.Lerp(0f, targetVolume, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;

            // Esperar hasta el próximo frame.
            yield return null;
        }

        // Asegurarse de que el volumen final sea exactamente el objetivo.
        musicSource.volume = targetVolume;
    }

    public void TriggerSceneChange(string sceneName)
    {
        // Iniciar el fade-out antes de cambiar de escena.
        StartCoroutine(FadeOutAndChangeScene(sceneName));
    }

    private System.Collections.IEnumerator FadeOutAndChangeScene(string sceneName)
    {
        float elapsedTime = 0f;
        float startVolume = musicSource.volume;

        while (elapsedTime < fadeDuration)
        {
            // Reducir el volumen gradualmente.
            musicSource.volume = Mathf.Lerp(startVolume, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;

            // Esperar hasta el próximo frame.
            yield return null;
        }

        // Asegurarse de que el volumen sea exactamente 0.
        musicSource.volume = 0f;

        // Cambiar a la nueva escena.
        SceneManager.LoadScene(sceneName);
    }
}
