using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimationController : MonoBehaviour
{
    public List<GameObject> animatedObjects; // List of GameObjects to animate
    public List<float> endYPositions; // List of final Y positions for each GameObject
    public List<AudioClip> moveAudioClips; // List of unique sound effects for each object
    public float animationDuration = 1f; // Duration of the animation

    private int currentObjectIndex = 0; // Index of the current object in the list
    private bool isAnimating = false; // To prevent multiple clicks during animation

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

        // Play the sound using AudioManager
        if (audioClip != null)
        {
            AudioManager.instance.PlaySFX(audioClip);
        }

        // Animate position
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


