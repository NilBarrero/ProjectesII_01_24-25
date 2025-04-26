using System.Collections;
using UnityEngine;

public class Cinematics : MonoBehaviour
{
    public float endYPosition = 0f; // Final position on the Y axis
    public float animationDuration = 1f; // Duration of the animation
    public AudioClip moveAudioClip; // Audio clip

    private RectTransform rectTransform; // Reference to the RectTransform

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        if (rectTransform != null)
        {
            StartCoroutine(AnimateImage());
        }
        else
        {
            Debug.LogWarning("CinematicAnimator requires a RectTransform component on the GameObject.");
        }
    }

    private IEnumerator AnimateImage()
    {
        Vector2 startPosition = rectTransform.anchoredPosition;
        Vector2 endPosition = new Vector2(startPosition.x, endYPosition);

        // Play the sound from AudioManager if a clip is assigned
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

        rectTransform.anchoredPosition = endPosition; // Ensure the exact final position
    }
}
