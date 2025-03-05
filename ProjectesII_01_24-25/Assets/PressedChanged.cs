using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedChanged : MonoBehaviour
{    // Este booleano indicar� si el objeto ha sido pulsado

    // Este booleano indicar� si el objeto ha sido pulsado
    public bool haSidoPulsado = false;

    // Referencia al Controller (GameManager)


    // Este m�todo se llama cuando el objeto es pulsado (clic)
    void OnMouseDown()
    {
        // Establecemos que ha sido pulsado
        haSidoPulsado = true;

        // Notificamos al GameManager (Controller) que el objeto ha sido pulsado

    }

    // Este m�todo se llama cada frame
    void Update()
    {
        // Si no hay clic, se asegura de que haSidoPulsado sea false
        if (!Input.GetMouseButton(0)) // Si no se mantiene presionado el bot�n izquierdo del rat�n
        {
            haSidoPulsado = false;
        }
    }
}
