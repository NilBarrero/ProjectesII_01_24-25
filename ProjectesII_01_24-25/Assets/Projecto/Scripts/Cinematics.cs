using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematics : MonoBehaviour
{
    public RectTransform[] images; // Asigna aquí las imágenes en el inspector
    public float delayBetweenAnimations = 0.5f; // Retraso entre cada animación
    public float animationDuration = 1f; // Duración de cada animación

    private void Start()
    {
        StartCoroutine(AnimateImagesSequentially());
    }

    private IEnumerator AnimateImagesSequentially()
    {
        foreach (var image in images)
        {
            yield return StartCoroutine(AnimateImage(image));
            yield return new WaitForSeconds(delayBetweenAnimations);
        }
    }

    private IEnumerator AnimateImage(RectTransform image)
    {
        Vector3 startPosition = image.anchoredPosition; // Posición inicial de la imagen
        Vector3 endPosition = Vector3.zero; // Centro (puedes cambiar esto según tu necesidad)

        float elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            image.anchoredPosition = Vector3.Lerp(startPosition, endPosition, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        image.anchoredPosition = endPosition; // Asegúrate de que termine exactamente en el centro
    }
}
