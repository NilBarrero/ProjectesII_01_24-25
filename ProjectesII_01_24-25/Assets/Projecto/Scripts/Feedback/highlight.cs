using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject activateDialogue;

    void Start()
    {
        
        if (activateDialogue != null)
        {
            activateDialogue.SetActive(false);
        }
    }

    
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        if (activateDialogue != null)
        {
            activateDialogue.SetActive(true);
        }
    }

    
    public void OnPointerExit(PointerEventData eventData)
    {
        
        if (activateDialogue != null)
        {
            activateDialogue.SetActive(false);
        }
    }
}


