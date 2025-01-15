using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    // Aqu� asigna tu textura de cursor personalizada en el inspector de Unity.
    public Texture2D cursorNuevo;
    public Texture2D cursorOriginal;
    

    // Este m�todo se llama cuando el cursor entra en el �rea del GameObject.
    private void OnMouseEnter()
    {
        // Cambiar el cursor cuando el rat�n entra en el GameObject
        Cursor.SetCursor(cursorNuevo, CursorMode.Auto);
    }

    // Este m�todo se llama cuando el cursor sale del �rea del GameObject.
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
