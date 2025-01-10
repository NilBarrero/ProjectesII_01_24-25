using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressed : MonoBehaviour
{
    // Este booleano indicará si el objeto ha sido pulsado
    public bool haSidoPulsado = false;

    // Referencia al Controller (GameManager)
    private Controller gameManager;

    // Este método se llama cada vez que el prefab es habilitado
    void OnEnable()
    {
        // Buscar el GameManager (Controller) en la escena
        gameManager = FindObjectOfType<Controller>();

        // Verificar si se ha encontrado el Controller
        if (gameManager == null)
        {
            Debug.LogError("¡No se encontró el GameManager en la escena!");
        }
    }

    // Este método se llama cuando el objeto es pulsado (clic)
    void OnMouseDown()
    {
        if (!haSidoPulsado)  // Solo procesar si no ha sido pulsado antes
        {
            // Establecemos que ha sido pulsado
            haSidoPulsado = true;

            // Notificamos al GameManager (Controller) que el objeto ha sido pulsado
            if (gameManager != null)
            {
                gameManager.ObjetoPulsado(this); // Pasamos 'this' como referencia al Pressed
            }
        }
    }
}


