using UnityEngine;

public class Cinematics : MonoBehaviour
{
    public float endYPosition = 0f;
    public float animationDuration = 1f;
    public AudioClip moveAudioClip;

    private void Start()
    {
        if (TryGetComponent(out RectTransform rectTransform))
            StartCoroutine(Animate(rectTransform));
        else
            Debug.LogWarning("CinematicAnimator requires a RectTransform component.");
    }

    private System.Collections.IEnumerator Animate(RectTransform rectTransform)
    {
        Vector2 start = rectTransform.anchoredPosition;
        Vector2 end = new(start.x, endYPosition);

        if (moveAudioClip) AudioManager.instance.PlaySFX(moveAudioClip);

        for (float t = 0; t < animationDuration; t += Time.deltaTime)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(start, end, t / animationDuration);
            yield return null;
        }

        rectTransform.anchoredPosition = end;
    }
}

