using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject activateDialogue;  // Referencia al GameObject de TextMeshPro

    void Start()
    {
        // Asegurarse de que el TextMeshPro esté desactivado al principio
        if (activateDialogue != null)
        {
            activateDialogue.SetActive(false);
        }
    }

    // Este método se llama cuando el ratón entra en el botón
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Activar el TextMeshPro cuando el ratón pasa por encima del botón
        if (activateDialogue != null)
        {
            activateDialogue.SetActive(true);
        }
    }

    // Este método se llama cuando el ratón sale del botón
    public void OnPointerExit(PointerEventData eventData)
    {
        // Desactivar el TextMeshPro cuando el ratón sale
        if (activateDialogue != null)
        {
            activateDialogue.SetActive(false);
        }
    }
}

