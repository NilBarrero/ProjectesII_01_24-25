using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HighlightManager : MonoBehaviour
{
    private List<GameObject> clickables = new List<GameObject>(); // Lista de objetos clicables
    private List<GameObject> draggables = new List<GameObject>(); // Lista de objetos arrastrables
    public Color clickHighlightColor = Color.yellow; // Color de resaltado para clicables
    public Color dragHighlightColor = Color.cyan; // Color de resaltado para arrastrables
    private List<Color> originalClickableColors = new List<Color>(); // Colores originales de clicables
    private List<Color> originalDraggableColors = new List<Color>(); // Colores originales de arrastrables
    private bool highlightActive = false; // Indica si el resaltado está activo
    private float highlightDuration = 1f; // Duración del resaltado en segundos
    private float highlightTimer = 0f; // Temporizador para la duración del resaltado
    private float fadeDuration = 0.5f; // Duración del fade out
    private float cooldownTime = 5f; // Tiempo de cooldown entre activaciones
    private float lastHighlightTime = -5f; // Momento en que se activó por última vez

    void Start()
    {
        // Encuentra los objetos según su etiqueta
        clickables.AddRange(GameObject.FindGameObjectsWithTag("Clicable"));
        draggables.AddRange(GameObject.FindGameObjectsWithTag("Arrastrable"));

        // Guarda sus colores originales
        foreach (var obj in clickables)
        {
            var spriteRenderer = obj.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null) originalClickableColors.Add(spriteRenderer.color);
            else originalClickableColors.Add(Color.white); // Asignar un valor por defecto si no tiene SpriteRenderer
        }
        foreach (var obj in draggables)
        {
            var spriteRenderer = obj.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null) originalDraggableColors.Add(spriteRenderer.color);
            else originalDraggableColors.Add(Color.white); // Asignar un valor por defecto si no tiene SpriteRenderer
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.time >= lastHighlightTime + cooldownTime) // Si se presiona el clic derecho y el cooldown terminó
        {
            lastHighlightTime = Time.time; // Registra el momento de activación
            highlightActive = true;
            highlightTimer = highlightDuration; // Inicia el temporizador

            // Resalta los objetos clicables
            foreach (GameObject obj in clickables)
            {
                var spriteRenderer = obj.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null) spriteRenderer.color = clickHighlightColor;
            }

            // Resalta los objetos arrastrables
            foreach (GameObject obj in draggables)
            {
                var spriteRenderer = obj.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null) spriteRenderer.color = dragHighlightColor;
            }
        }

        if (highlightActive) // Si el resaltado está activo
        {
            highlightTimer -= Time.deltaTime; // Reduce el temporizador con el tiempo
            if (highlightTimer <= 0f) // Si el temporizador llega a cero
            {
                highlightActive = false; // Desactiva el resaltado
                StartCoroutine(FadeOutColors());
            }
        }
    }

    private IEnumerator FadeOutColors()
    {
        float elapsedTime = 0f;

        // Realiza el fade out para cada objeto
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

        // Asegura que el color final sea exactamente el original
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




