using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimationController : MonoBehaviour
{
    public List<GameObject> animatedObjects; // Lista de GameObjects que se animarán
    public List<float> endYPositions; // Lista de posiciones finales en el eje Y para cada GameObject
    public float animationDuration = 1f; // Duración de la animación
    public AudioClip moveAudioClip; // Archivo de audio para reproducir

    private int currentObjectIndex = 0; // Índice del objeto actual en la lista
    private bool isAnimating = false; // Para evitar múltiples clics durante la animación

    private void Update()
    {
        // Detectar clic en cualquier parte de la pantalla
        if (Input.GetMouseButtonDown(0) && !isAnimating && currentObjectIndex < animatedObjects.Count)
        {
            // Inicia la animación del objeto actual
            StartCoroutine(AnimateObject(animatedObjects[currentObjectIndex], endYPositions[currentObjectIndex]));
            currentObjectIndex++; // Incrementa al siguiente objeto en la lista
        }
    }

    private IEnumerator AnimateObject(GameObject obj, float endYPosition)
    {
        isAnimating = true; // Bloquear múltiples clics mientras la animación está en curso

        RectTransform rectTransform = obj.GetComponent<RectTransform>();
        AudioSource audioSource = obj.GetComponent<AudioSource>();

        // Si el objeto no tiene AudioSource, agregarlo
        if (audioSource == null)
        {
            audioSource = obj.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.clip = moveAudioClip;
        }

        // Configurar la posición inicial
        Vector2 startPosition = rectTransform.anchoredPosition;
        Vector2 endPosition = new Vector2(startPosition.x, endYPosition); // Solo cambiará el eje Y

        // Reproducir audio si está asignado
        if (audioSource != null && moveAudioClip != null)
        {
            audioSource.Play();
        }

        // Animar posición
        float elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = endPosition; // Asegurar que termine exactamente en la posición final

        isAnimating = false; // Permitir nuevos clics
    }
}
