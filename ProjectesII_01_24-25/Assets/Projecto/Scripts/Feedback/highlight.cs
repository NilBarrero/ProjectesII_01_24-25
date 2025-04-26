using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject activateDialogue;  // Private reference to the GameObject to activate

    void Start()
    {
        // Ensure that the TextMeshPro is deactivated at the start
        if (activateDialogue != null)
        {
            activateDialogue.SetActive(false);
        }
    }

    // This method is called when the mouse enters the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Activate the TextMeshPro when the mouse hovers over the button
        if (activateDialogue != null)
        {
            activateDialogue.SetActive(true);
        }
    }

    // This method is called when the mouse exits the button
    public void OnPointerExit(PointerEventData eventData)
    {
        // Deactivate the TextMeshPro when the mouse exits
        if (activateDialogue != null)
        {
            activateDialogue.SetActive(false);
        }
    }
}


