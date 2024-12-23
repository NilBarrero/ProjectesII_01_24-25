using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateanddeactivateSpeech : MonoBehaviour
{
    // Aseg�rate de asignar esto en el Inspector
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
        if (!isdeactivated)  // A�adir una comprobaci�n null para evitar errores
        {
            dialogue.SetActive(true);
        }
        else
        {
            dialogue.SetActive(false);
        }
    }
}

