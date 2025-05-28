using System.Collections;
using UnityEngine;

public class HighlightOnHover : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color originalColor;
    public Color highlightColor = Color.yellow;


    
    public Texture2D customCursor;
    public Vector2 cursorHotspot = new Vector2(16, 16);

    void Start()
    {
        

        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }
    }

    private void Update()
    {
        
 
    }

    void OnMouseEnter()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = highlightColor; 
        }

        
        if (customCursor != null)
        {
            UnityEngine.Cursor.SetCursor(customCursor, new Vector2(customCursor.width / 2, customCursor.height / 2), CursorMode.Auto);
        }

    }

    void OnMouseExit()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = originalColor;
        }

        
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    
    void OnDestroy()
    {
  
    }
}

