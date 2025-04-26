using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimationController : MonoBehaviour
{
    public List<GameObject> animatedObjects; // Lista de GameObjects que se animar�n
    public List<float> endYPositions; // Lista de posiciones finales en el eje Y para cada GameObject
    public List<AudioClip> moveAudioClips; // Lista de efectos de sonido �nicos para cada objeto
    public float animationDuration = 1f; // Duraci�n de la animaci�n

    private int currentObjectIndex = 0; // �ndice del objeto actual en la lista
    private bool isAnimating = false; // Para evitar m�ltiples clics durante la animaci�n

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAnimating && currentObjectIndex < animatedObjects.Count)
        {
            StartCoroutine(AnimateObject(animatedObjects[currentObjectIndex], endYPositions[currentObjectIndex], moveAudioClips[currentObjectIndex]));
            currentObjectIndex++;
        }
    }

    private IEnumerator AnimateObject(GameObject obj, float endYPosition, AudioClip audioClip)
    {
        isAnimating = true;

        RectTransform rectTransform = obj.GetComponent<RectTransform>();

        // Reproduce el sonido usando AudioManager
        if (audioClip != null)
        {
            AudioManager.instance.PlaySFX(audioClip);
        }

        // Animar posici�n
        Vector2 startPosition = rectTransform.anchoredPosition;
        Vector2 endPosition = new Vector2(startPosition.x, endYPosition);
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = endPosition;

        isAnimating = false;
    }
}

