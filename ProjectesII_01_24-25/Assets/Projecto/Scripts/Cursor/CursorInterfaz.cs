using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InterfaceCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Add a reference for the custom cursor
    public Texture2D customCursor; // The cursor you want to use
    public Vector2 cursorHotspot = new Vector2(16, 16); // Defines the center of the cursor

    private void Start()
    {
        // Check if the Button component exists on the GameObject
        if (GetComponent<Button>() == null)
        {
            Debug.LogError("This script must be attached to a GameObject with a Button component.");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Change the cursor when hovering over the button
        if (customCursor != null)
        {
            // Ensure you're using UnityEngine.Cursor to avoid conflicts
            UnityEngine.Cursor.SetCursor(customCursor, cursorHotspot, CursorMode.Auto);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Restore the cursor to the default value
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
