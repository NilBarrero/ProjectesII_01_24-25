using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ButtonInteraction : MonoBehaviour
{
    private Vector2 startPos;
    private Renderer objectRenderer;
    public Texture2D customCursor; // El cursor que quieres usar
    public Vector2 cursorHotspot = new Vector2(16, 16); // Define el centro del cursor
    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        startPos.y += 2.0f;
        startPos.x += 2.0f;
        transform.localPosition = new Vector2(startPos.x, startPos.y);
    }

    void OnMouseEnter()
    {
        if (objectRenderer != null)
        {
            transform.position = new Vector2(startPos.x, startPos.y);   
        }

        // Cambiar el cursor cuando el mouse pasa por encima
        if (customCursor != null)
        {
            UnityEngine.Cursor.SetCursor(customCursor, cursorHotspot, CursorMode.Auto);
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
}
