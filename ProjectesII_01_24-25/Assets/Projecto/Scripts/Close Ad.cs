using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAd : MonoBehaviour
{
    // Referencia al script Counter
    public Counter counter;

    private void OnMouseDown()
    {
        // Asegurarse de que 'counter' no sea null
        if (counter != null)
        {
            // Llamar al método CloseSpecificAd en Counter, pasando el anuncio actual
            counter.CloseSpecificAd(gameObject);  // 'gameObject' es el anuncio sobre el que se hace clic
        }
        else
        {
            Debug.LogError("No se ha asignado el script Counter en el Inspector.");
        }
    }
}
