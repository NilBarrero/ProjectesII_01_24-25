using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HighlightManager : MonoBehaviour
{
    private List<GameObject> clickables = new List<GameObject>(); // List of clickable objects
    private List<GameObject> draggables = new List<GameObject>(); // List of draggable objects
    public Color clickHighlightColor = Color.yellow; // Highlight color for clickables
    public Color dragHighlightColor = Color.cyan; // Highlight color for draggables
    private List<Color> originalClickableColors = new List<Color>(); // Original colors of clickables
    private List<Color> originalDraggableColors = new List<Color>(); // Original colors of draggables
    private bool highlightActive = false; // Indicates if highlight is active
    private float highlightDuration = 1f; // Highlight duration in seconds
    private float highlightTimer = 0f; // Timer for the highlight duration
    private float fadeDuration = 0.5f; // Fade out duration
    private float cooldownTime = 5f; // Cooldown time between activations
    private float lastHighlightTime = -5f; // The last time highlighting was activated

    void Start()
    {
        // Find objects by their tag
        clickables.AddRange(GameObject.FindGameObjectsWithTag("Clicable"));
        draggables.AddRange(GameObject.FindGameObjectsWithTag("Arrastrable"));

        // Save their original colors
        foreach (var obj in clickables)
        {
            var spriteRenderer = obj.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null) originalClickableColors.Add(spriteRenderer.color);
            else originalClickableColors.Add(Color.white); // Assign a default value if no SpriteRenderer
        }
        foreach (var obj in draggables)
        {
            var spriteRenderer = obj.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null) originalDraggableColors.Add(spriteRenderer.color);
            else originalDraggableColors.Add(Color.white); // Assign a default value if no SpriteRenderer
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.time >= lastHighlightTime + cooldownTime) // If right-click is pressed and cooldown has passed
        {
            lastHighlightTime = Time.time; // Record the activation time
            highlightActive = true;
            highlightTimer = highlightDuration; // Start the highlight timer

            // Highlight clickable objects
            foreach (GameObject obj in clickables)
            {
                var spriteRenderer = obj.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null) spriteRenderer.color = clickHighlightColor;
            }

            // Highlight draggable objects
            foreach (GameObject obj in draggables)
            {
                var spriteRenderer = obj.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null) spriteRenderer.color = dragHighlightColor;
            }
        }

        if (highlightActive) // If highlighting is active
        {
            highlightTimer -= Time.deltaTime; // Reduce the timer over time
            if (highlightTimer <= 0f) // If the timer reaches zero
            {
                highlightActive = false; // Deactivate highlighting
                StartCoroutine(FadeOutColors());
            }
        }
    }

    private IEnumerator FadeOutColors()
    {
        float elapsedTime = 0f;

        // Perform fade out for each object
        while (elapsedTime < fadeDuration)
        {
            float lerpFactor = elapsedTime / fadeDuration;

            for (int i = 0; i < clickables.Count; i++)
            {
                var spriteRenderer = clickables[i].GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = Color.Lerp(clickHighlightColor, originalClickableColors[i], lerpFactor);
                }
            }

            for (int i = 0; i < draggables.Count; i++)
            {
                var spriteRenderer = draggables[i].GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = Color.Lerp(dragHighlightColor, originalDraggableColors[i], lerpFactor);
                }
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final color matches the original exactly
        for (int i = 0; i < clickables.Count; i++)
        {
            var spriteRenderer = clickables[i].GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
                spriteRenderer.color = originalClickableColors[i];
        }

        for (int i = 0; i < draggables.Count; i++)
        {
            var spriteRenderer = draggables[i].GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
                spriteRenderer.color = originalDraggableColors[i];
        }
    }
}



