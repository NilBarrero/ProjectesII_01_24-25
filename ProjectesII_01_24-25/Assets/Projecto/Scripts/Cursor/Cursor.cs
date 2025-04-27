using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    // Assign your custom cursor texture in the Unity inspector.
    public Texture2D newCursor;
    public Texture2D originalCursor;

    // This method is called when the cursor enters the area of the GameObject.
    private void OnMouseEnter()
    {
        // Change the cursor when the mouse enters the GameObject
        Cursor.SetCursor(newCursor, Vector2.zero, CursorMode.Auto);
    }

    // This method is called when the cursor exits the area of the GameObject.
    private void OnMouseExit()
    {
        // Restore the original cursor when exiting the GameObject
        Cursor.SetCursor(originalCursor, Vector2.zero, CursorMode.Auto);
    }
}

