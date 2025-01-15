using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorInterfaz : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Añadir una referencia para el cursor personalizado
    public Texture2D customCursor; // El cursor que quieres usar
    public Vector2 cursorHotspot = new Vector2(16, 16); // Define el centro del cursor

    private void Start()
    {
        // Comprobar que el componente Button existe en el GameObject
        if (GetComponent<Button>() == null)
        {
            Debug.LogError("Este script debe estar adjunto a un GameObject que tenga un componente Button.");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Cambiar el cursor al pasar sobre el botón
        if (customCursor != null)
        {
            // Asegúrate de usar UnityEngine.Cursor para evitar conflictos
            UnityEngine.Cursor.SetCursor(customCursor, cursorHotspot, CursorMode.Auto);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Restaurar el cursor al valor predeterminado
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}