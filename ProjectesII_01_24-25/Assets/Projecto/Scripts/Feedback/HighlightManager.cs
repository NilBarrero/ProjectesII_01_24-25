using UnityEngine;
using System.Collections;

public class HighlightManager : MonoBehaviour
{
    private GameObject[] clickables; // Lista de objetos clicables
    private GameObject[] draggables; // Lista de objetos arrastrables
    public Color clickHighlightColor = Color.yellow; // Color de resaltado para clicables
    public Color dragHighlightColor = Color.cyan; // Color de resaltado para arrastrables
    private Color[] originalClickableColors; // Colores originales de clicables
    private Color[] originalDraggableColors; // Colores originales de arrastrables
    private bool highlightActive = false; // Indica si el resaltado está activo
    private float highlightDuration = 1f; // Duración del resaltado en segundos
    private float highlightTimer = 0f; // Temporizador para la duración del resaltado
    private float fadeDuration = 0.5f; // Duración del fade out
    private float cooldownTime = 5f; // Tiempo de cooldown entre activaciones
    private float lastHighlightTime = -5f; // Momento en que se activó por última vez

    void Start()
    {
        // Encuentra los objetos según su etiqueta
        clickables = GameObject.FindGameObjectsWithTag("Clicable");
        draggables = GameObject.FindGameObjectsWithTag("Arrastrable");

        // Guarda sus colores originales
        originalClickableColors = new Color[clickables.Length];
        originalDraggableColors = new Color[draggables.Length];

        for (int i = 0; i < clickables.Length; i++)
        {
            originalClickableColors[i] = clickables[i].GetComponent<SpriteRenderer>().color;
        }
        for (int i = 0; i < draggables.Length; i++)
        {
            originalDraggableColors[i] = draggables[i].GetComponent<SpriteRenderer>().color;
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
                obj.GetComponent<SpriteRenderer>().color = clickHighlightColor;
            }

            // Resalta los objetos arrastrables
            foreach (GameObject obj in draggables)
            {
                obj.GetComponent<SpriteRenderer>().color = dragHighlightColor;
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

            for (int i = 0; i < clickables.Length; i++)
            {
                SpriteRenderer spriteRenderer = clickables[i].GetComponent<SpriteRenderer>();
                spriteRenderer.color = Color.Lerp(clickHighlightColor, originalClickableColors[i], lerpFactor);
            }

            for (int i = 0; i < draggables.Length; i++)
            {
                SpriteRenderer spriteRenderer = draggables[i].GetComponent<SpriteRenderer>();
                spriteRenderer.color = Color.Lerp(dragHighlightColor, originalDraggableColors[i], lerpFactor);
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegura que el color final sea exactamente el original
        for (int i = 0; i < clickables.Length; i++)
        {
            clickables[i].GetComponent<SpriteRenderer>().color = originalClickableColors[i];
        }

        for (int i = 0; i < draggables.Length; i++)
        {
            draggables[i].GetComponent<SpriteRenderer>().color = originalDraggableColors[i];
        }
    }
}



