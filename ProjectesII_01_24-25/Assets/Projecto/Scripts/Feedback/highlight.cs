using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject activateDialogue;  // Private reference to the GameObject to activate

    void Start()
    {
        // Asegurarse de que el TextMeshPro est� desactivado al principio
        if (activateDialogue != null)
        {
            activateDialogue.SetActive(false);
        }
    }

    // Este m�todo se llama cuando el rat�n entra en el bot�n
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Activar el TextMeshPro cuando el rat�n pasa por encima del bot�n
        if (activateDialogue != null)
        {
            activateDialogue.SetActive(true);
        }
    }

    // Este m�todo se llama cuando el rat�n sale del bot�n
    public void OnPointerExit(PointerEventData eventData)
    {
        // Desactivar el TextMeshPro cuando el rat�n sale
        if (activateDialogue != null)
        {
            activateDialogue.SetActive(false);
        }
    }
}


