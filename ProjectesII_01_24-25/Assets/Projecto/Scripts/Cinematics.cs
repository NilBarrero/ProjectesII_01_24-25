using System.Collections;
using UnityEngine;

public class Cinematics : MonoBehaviour
{
    public float endYPosition = 0f; // Posición final en el eje Y
    public float animationDuration = 1f; // Duración de la animación
    public float delayBeforeAnimation = 0f; // Retraso antes de comenzar la animación
    public AudioClip moveAudioClip; // Archivo de audio para reproducir

    private RectTransform rectTransform; // Referencia al RectTransform
    private AudioSource audioSource; // Referencia al AudioSource

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        audioSource = gameObject.AddComponent<AudioSource>(); // Agrega un AudioSource si no existe
        audioSource.playOnAwake = false;

        if (moveAudioClip != null)
        {
            audioSource.clip = moveAudioClip;
        }
        else
        {
            Debug.LogWarning("No se asignó ningún clip de audio.");
        }

        if (rectTransform != null)
        {
            StartCoroutine(AnimateImage());
        }
        else
        {
            Debug.LogWarning("CinematicAnimator requiere un componente RectTransform en el GameObject.");
        }
    }

    private IEnumerator AnimateImage()
    {
        yield return new WaitForSeconds(delayBeforeAnimation); // Retraso antes de la animación

        Vector2 startPosition = rectTransform.anchoredPosition; // Posición inicial de la imagen
        Vector2 endPosition = new Vector2(startPosition.x, endYPosition); // Solo cambia el eje Y

        if (audioSource != null && moveAudioClip != null)
        {
            audioSource.Play(); // Reproduce el audio al inicio de la animación
        }

        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = endPosition; // Asegúrate de que termine exactamente en la posición final
    }
}

