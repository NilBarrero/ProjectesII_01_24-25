using System.Collections;
using UnityEngine;

public class Cinematics : MonoBehaviour
{
    public float endYPosition = 0f; // Posición final en el eje Y
    public float animationDuration = 1f; // Duración de la animación
    public AudioClip moveAudioClip; // Clip de audio

    private RectTransform rectTransform; // Referencia al RectTransform

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

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
        Vector2 startPosition = rectTransform.anchoredPosition;
        Vector2 endPosition = new Vector2(startPosition.x, endYPosition);

        // Reproduce el sonido desde AudioManager si hay un clip asignado
        if (moveAudioClip != null)
        {
            AudioManager.instance.PlaySFX(moveAudioClip);
        }

        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = endPosition; // Asegurar la posición final exacta
    }
}

