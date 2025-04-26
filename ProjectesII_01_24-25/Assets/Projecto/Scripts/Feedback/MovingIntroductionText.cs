using System.Collections;
using UnityEngine;

public class MovingIntroductionText : MonoBehaviour
{
    public GameObject text; // The text GameObject (UI)
    public GameObject background; // The background GameObject (in the 2D world)
    public float endYPosition = 1000f; // Final Y position (off-screen)
    public float animationDuration = 1f; // Duration of the animation
    public float stayingTime = 2f; // Wait time before starting the animation

    private bool isAnimating = false; // To avoid multiple clicks during the animation
    private bool timeIsUp = false; // Controls whether the wait time has passed

    private void Start()
    {
        // Call the timer only once at the beginning
        StartCoroutine(TimerCoroutine());
    }

    private void Update()
    {
        if (timeIsUp && !isAnimating)
        {
            // Start the animation if it's not already running
            StartCoroutine(AnimateObjects());
        }
    }

    private IEnumerator AnimateObjects()
    {
        isAnimating = true; // Block multiple clicks while the animation is running

        // Check if references are not null
        if (text == null || background == null) yield break;

        // Get the RectTransform of the UI objects (text)
        RectTransform textRectTransform = text.GetComponent<RectTransform>();
        // Get the Transform of the background (2D world GameObject)
        Transform backgroundTransform = background.GetComponent<Transform>();

        // Save the initial positions
        Vector2 textStartPosition = textRectTransform.anchoredPosition;
        Vector3 backgroundStartPosition = backgroundTransform.position;

        // The animation begins
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            // Animate both objects simultaneously using Lerp
            float t = elapsedTime / animationDuration;

            // Move the text (UI) on the Y-axis
            textRectTransform.anchoredPosition = Vector2.Lerp(textStartPosition, new Vector2(textStartPosition.x, endYPosition), t);

            // Move the background (2D GameObject) on the Y-axis
            backgroundTransform.position = Vector3.Lerp(backgroundStartPosition, new Vector3(backgroundStartPosition.x, endYPosition, backgroundStartPosition.z), t);

            elapsedTime += Time.deltaTime; // Increase the elapsed time
            yield return null; // Wait for one frame
        }

        // Ensure both objects reach the final position
        textRectTransform.anchoredPosition = new Vector2(textRectTransform.anchoredPosition.x, endYPosition);
        backgroundTransform.position = new Vector3(backgroundTransform.position.x, endYPosition, backgroundTransform.position.z);

        isAnimating = false; // Allow new clicks and animations
    }

    private IEnumerator TimerCoroutine()
    {
        // Wait for the specified time before starting the animation
        yield return new WaitForSeconds(stayingTime);

        // This will run after the time has passed
        timeIsUp = true;
    }
}

