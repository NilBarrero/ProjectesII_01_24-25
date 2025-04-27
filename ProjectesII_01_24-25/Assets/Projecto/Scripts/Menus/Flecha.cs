using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flecha : MonoBehaviour
{
    public int numberOfArrow;  // El número de la flecha actual
    public GameObject arrow;   // El GameObject de la flecha

    void OnEnable()
    {
        // Primero, desactivamos la flecha al inicio


        // Leemos el número de la última escena guardada
        int lastScene = PlayerPrefs.GetInt("LastScene", -1); // Si no existe, devuelve -1

        Debug.Log("Última escena guardada: " + lastScene);

        // Comprobamos si el número de la flecha coincide con la última escena jugada
        if (numberOfArrow == lastScene)
        {
            Debug.Log("La flecha debe ser activada.");
            arrow.SetActive(true);  // Activamos la flecha si el número de la flecha coincide
        }
        else
        {
            Debug.Log("La flecha no se activa.");
        }
    }
}
