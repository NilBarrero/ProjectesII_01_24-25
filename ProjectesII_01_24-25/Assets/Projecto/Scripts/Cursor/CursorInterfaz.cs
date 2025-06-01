using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InterfaceCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Texture2D customCursor; 
    public Vector2 cursorHotspot = new Vector2(16, 16); 

    private void Start()
    {
        if (GetComponent<Button>() == null)
        {
            Debug.LogError("This script must be attached to a GameObject with a Button component.");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (customCursor != null)
        {
            UnityEngine.Cursor.SetCursor(customCursor, cursorHotspot, CursorMode.Auto);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
