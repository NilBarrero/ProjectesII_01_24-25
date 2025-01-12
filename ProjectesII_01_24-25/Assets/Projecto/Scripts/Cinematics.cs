using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematics : MonoBehaviour
{
    public float endYPosition = 0f; // Posici�n final en el eje Y
    public float animationDuration = 1f; // Duraci�n de la animaci�n
    public float delayBeforeAnimation = 0f; // Retraso antes de comenzar la animaci�n

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
        yield return new WaitForSeconds(delayBeforeAnimation); // Retraso antes de la animaci�n

        Vector2 startPosition = rectTransform.anchoredPosition; // Posici�n inicial de la imagen
        Vector2 endPosition = new Vector2(startPosition.x, endYPosition); // Solo cambia el eje Y

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
