using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flecha : MonoBehaviour
{
    public int numberOfArrow;  // El n�mero de la flecha actual
    public GameObject arrow;   // El GameObject de la flecha

    void OnEnable()
    {
        // Primero, desactivamos la flecha al inicio


        // Leemos el n�mero de la �ltima escena guardada
        int lastScene = PlayerPrefs.GetInt("LastScene", -1); // Si no existe, devuelve -1

        Debug.Log("�ltima escena guardada: " + lastScene);

        // Comprobamos si el n�mero de la flecha coincide con la �ltima escena jugada
        if (numberOfArrow == lastScene)
        {
            Debug.Log("La flecha debe ser activada.");
            arrow.SetActive(true);  // Activamos la flecha si el n�mero de la flecha coincide
        }
        else
        {
            Debug.Log("La flecha no se activa.");
        }
    }
}
