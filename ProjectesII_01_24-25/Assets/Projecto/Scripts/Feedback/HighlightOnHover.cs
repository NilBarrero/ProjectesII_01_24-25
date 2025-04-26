using System.Collections;
using UnityEngine;

public class HighlightOnHover : MonoBehaviour
{
    private Renderer objectRenderer;
    public GameObject activateDialogue;
    public GameObject dialogueinactive;
    private Color originalColor;
    public Color highlightColor = Color.yellow; // Cambia este color según tu necesidad
    public ParticleSystem particles;

    // Añadir una referencia para el cursor personalizado
    public Texture2D customCursor; // El cursor que quieres usar
    public Vector2 cursorHotspot = new Vector2(16, 16); // Define el centro del cursor

    void Start()
    {
        // Inicializa los objetos y detiene las partículas al inicio
        if (activateDialogue != null)
        {
            activateDialogue.SetActive(false);
        }
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color; // Guarda el color original
        }
        if (particles != null)
        {
            particles.Stop();
        }
    }

    private void Update()
    {
        // Actualiza el estado del diálogo
        if (activateDialogue.activeSelf)
        {
            dialogueinactive.SetActive(false);
        }
        else
        {
            dialogueinactive.SetActive(true);
        }
    }

    void OnMouseEnter()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = highlightColor; // Cambia al color de resaltado
        }

        // Cambiar el cursor cuando el mouse pasa por encima
        if (customCursor != null)
        {
            UnityEngine.Cursor.SetCursor(customCursor, new Vector2(customCursor.width / 2, customCursor.height / 2), CursorMode.Auto);
        }

        // Activar partículas y diálogo si no está activo
        if (!activateDialogue.activeSelf && particles != null)
        {
            StartCoroutine(Activate(2.5f, 0f, activateDialogue));
        }
    }

    void OnMouseExit()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = originalColor; // Vuelve al color original
        }

        // Restaurar el cursor al valor predeterminado
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private IEnumerator Activate(float timeOut, float timeIn, GameObject gameobject)
    {
        // Espera el tiempo de entrada (si aplica)
        yield return new WaitForSeconds(timeIn);

        // Activa partículas y el diálogo
        if (particles != null)
        {
            particles.Play();
        }
        gameobject.SetActive(true);

        // Espera el tiempo de salida
        yield return new WaitForSeconds(timeOut);

        // Detiene las partículas y desactiva el diálogo
        if (particles != null)
        {
            particles.Stop();
        }
        gameobject.SetActive(false);
    }

    // Este método desactiva el diálogo cuando el GameObject que contiene este script es destruido
    void OnDestroy()
    {
        // Si el objeto que contiene este script se destruye, desactivar el diálogo
        if (activateDialogue != null)
        {
            activateDialogue.SetActive(false);
        }
    }
}


