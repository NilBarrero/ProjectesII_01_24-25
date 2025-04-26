using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScriptInMap : MonoBehaviour
{
    public GameObject[] gameObjectsAActivar; // Array para almacenar los gameobjects a activar/desactivar

    // Función que se llama al hacer clic en el botón
    public void Activar()
    {
        Debug.Log("¡Activar() fue llamada!");

        foreach (GameObject obj in gameObjectsAActivar)
        {
            if (obj != null)
            {
                Debug.Log("Activando: " + obj.name); // Verifica qué objeto estás activando
                obj.SetActive(true); // Activa el gameobject
            }
        }
    }
}

