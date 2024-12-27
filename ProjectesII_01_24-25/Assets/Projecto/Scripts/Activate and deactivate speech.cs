using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateanddeactivateSpeech : MonoBehaviour
{
    // Asegúrate de asignar esto en el Inspector
    public GameObject dialogue;
    public GameObject character;
    public bool isdeactivated = true;

    // Start is called before the first frame update
    void Start()
    {
        dialogue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isdeactivated)  // Añadir una comprobación null para evitar errores
        {
            dialogue.SetActive(true);
        }
        else
        {
            dialogue.SetActive(false);
        }
    }
}

