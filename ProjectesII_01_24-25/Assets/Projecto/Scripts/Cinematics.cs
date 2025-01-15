using System.Collections;
using UnityEngine;

public class Cinematics : MonoBehaviour
{
    public float endYPosition = 0f; // Posici�n final en el eje Y
    public float animationDuration = 1f; // Duraci�n de la animaci�n
    public float delayBeforeAnimation = 0f; // Retraso antes de comenzar la animaci�n
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
            Debug.LogWarning("No se asign� ning�n clip de audio.");
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
        yield return new WaitForSeconds(delayBeforeAnimation); // Retraso antes de la animaci�n

        Vector2 startPosition = rectTransform.anchoredPosition; // Posici�n inicial de la imagen
        Vector2 endPosition = new Vector2(startPosition.x, endYPosition); // Solo cambia el eje Y

        if (audioSource != null && moveAudioClip != null)
        {
            audioSource.Play(); // Reproduce el audio al inicio de la animaci�n
        }

        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = endPosition; // Aseg�rate de que termine exactamente en la posici�n final
    }
}

