using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D newCursor;
    public Texture2D originalCursor;

    private void OnMouseEnter()
    { 
        Cursor.SetCursor(newCursor, Vector2.zero, CursorMode.Auto);
    }

    
    private void OnMouseExit()
    {
        Cursor.SetCursor(originalCursor, Vector2.zero, CursorMode.Auto);
    }
}

