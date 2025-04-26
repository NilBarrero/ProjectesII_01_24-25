using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarPopup : MonoBehaviour
{
    [Tooltip("Objeto a destruir al hacer clic (normalmente el padre)")]
    public GameObject objetoADestruir;

    public void Destruir()
    {
        if (objetoADestruir != null)
        {
            Destroy(objetoADestruir);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el objeto a destruir.");
        }
    }

}