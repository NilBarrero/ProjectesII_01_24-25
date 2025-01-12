using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    // Aquí asigna tu textura de cursor personalizada en el inspector de Unity.
    public Texture2D cursorNuevo;
    public Texture2D cursorOriginal;
    

    // Este método se llama cuando el cursor entra en el área del GameObject.
    private void OnMouseEnter()
    {
        // Cambiar el cursor cuando el ratón entra en el GameObject
        Cursor.SetCursor(cursorNuevo, CursorMode.Auto);
    }

    // Este método se llama cuando el cursor sale del área del GameObject.
    private void OnMouseExit()
    {
        // Restaurar el cursor original cuando sale del GameObject
        Cursor.SetCursor(cursorOriginal, CursorMode.Auto);
    }

    private static void SetCursor(Texture2D cursorOriginal, CursorMode auto)
    {
        throw new NotImplementedException();
    }
}
