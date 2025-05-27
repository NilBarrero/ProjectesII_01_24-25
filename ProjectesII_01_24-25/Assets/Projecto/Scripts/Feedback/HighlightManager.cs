using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HighlightManager : MonoBehaviour
{
    private List<GameObject> clickables = new List<GameObject>();
    private List<GameObject> draggables = new List<GameObject>();
    public Color clickHighlightColor = Color.yellow;
    public Color dragHighlightColor = Color.cyan;
    private List<Color> originalClickableColors = new List<Color>();
    private List<Color> originalDraggableColors = new List<Color>();
    private bool highlightActive = false;
    private float highlightDuration = 1f;
    private float highlightTimer = 0f;
    private float fadeDuration = 0.5f;
    private float cooldownTime = 5f;
    private float lastHighlightTime = -5f;

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
            else originalClickableColors.Add(Color.white);
        }
        foreach (var obj in draggables)
        {
            var spriteRenderer = obj.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null) originalDraggableColors.Add(spriteRenderer.color);
            else originalDraggableColors.Add(Color.white);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.time >= lastHighlightTime + cooldownTime)
        {
            lastHighlightTime = Time.time;
            highlightActive = true;
            highlightTimer = highlightDuration;

           
            foreach (GameObject obj in clickables)
            {
                var spriteRenderer = obj.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null) spriteRenderer.color = clickHighlightColor;
            }

         
            foreach (GameObject obj in draggables)
            {
                var spriteRenderer = obj.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null) spriteRenderer.color = dragHighlightColor;
            }
        }

        if (highlightActive)
        {
            highlightTimer -= Time.deltaTime;
            if (highlightTimer <= 0f)
            {
                highlightActive = false; 
                StartCoroutine(FadeOutColors());
            }
        }
    }

    private IEnumerator FadeOutColors()
    {
        float elapsedTime = 0f;

  
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



