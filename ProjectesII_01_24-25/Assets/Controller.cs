using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Contador que se incrementa cuando un objeto es pulsado
    public int contador = 0;

    // Este método es llamado cuando un GameObject ha sido pulsado
    public void ObjetoPulsado(Pressed botonPulsado)
    {
        // Si el objeto ha sido pulsado, sumamos 1 al contador
        if (botonPulsado != null && botonPulsado.haSidoPulsado)
        {
            contador++; // Incrementamos el contador
            Debug.Log("Contador: " + contador);
        }

        // Después de procesar el evento, reiniciamos el estado de pulsado
        botonPulsado.haSidoPulsado = false; // Reiniciamos el estado de pulsado
    }
}

