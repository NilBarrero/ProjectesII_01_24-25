using System.Collections;
using UnityEngine;

public class HighlightOnHover : MonoBehaviour
{
    private Renderer objectRenderer;
    public GameObject activateDialogue;
    public bool activeDialogueActive = false;
    private ActivateanddeactivateSpeech dialogue;
    public GameObject dialogueinactive;
    private Color originalColor;
    public Color highlightColor = Color.yellow; // Cambia este color según tu necesidad
    public ParticleSystem particles;

    // Añadir una referencia para el cursor personalizado
    public Texture2D customCursor; // El cursor que quieres usar
    public Vector2 cursorHotspot = new Vector2(16, 16); // Define el centro del cursor

    void Start()
    {
        activateDialogue.SetActive(false);
        activeDialogueActive = false;

        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color; // Guarda el color original
            particles.Stop();
        }
    }

    private void Update()
    {
        if (activeDialogueActive)
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
            UnityEngine.Cursor.SetCursor(customCursor, cursorHotspot, CursorMode.Auto);
        }

        if (!activeDialogueActive)
        {
            if(particles != null)
            {
                StartCoroutine(Activate(2.5f, 0f, activateDialogue));
                activeDialogueActive = true;
            }
           
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
        yield return new WaitForSeconds(timeIn);
        // Cambiar el color al de resaltado
        particles.Play();
        gameobject.SetActive(true);

        // Esperar el tiempo especificado
        yield return new WaitForSeconds(timeOut);

        // Volver al color original
        particles.Play();
        gameobject.SetActive(false);
        activeDialogueActive = false;
    }

    // Este método desactiva el diálogo cuando el GameObject que contiene este script es destruido
    void OnDestroy()
    {
        // Si el objeto que contiene este script se destruye, desactivar el diálogo
        if (activateDialogue != null)
        {
            activateDialogue.SetActive(false);
            activeDialogueActive = false;  // Asegúrate de actualizar el estado
        }
    }
}

