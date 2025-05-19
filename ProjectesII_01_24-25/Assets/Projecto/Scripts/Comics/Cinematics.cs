using System.Collections;
using UnityEngine;

public class Cinematics : MonoBehaviour
{
    public float endYPosition = 0f; 
    public float animationDuration = 1f; 
    public AudioClip moveAudioClip;

    private RectTransform rectTransform; 

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

        rectTransform.anchoredPosition = endPosition; 
    }
}
