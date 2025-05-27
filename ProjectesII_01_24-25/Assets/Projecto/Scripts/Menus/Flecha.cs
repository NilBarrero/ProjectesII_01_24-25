using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flecha : MonoBehaviour
{
    public int numberOfArrow;
    public GameObject arrow;

    void OnEnable()
    {
        int lastScene = PlayerPrefs.GetInt("LastScene", -1);

        Debug.Log("Última escena guardada: " + lastScene);

        if (numberOfArrow == lastScene)
        {
            Debug.Log("La flecha debe ser activada.");
            arrow.SetActive(true);
        }
        else
        {
            Debug.Log("La flecha no se activa.");
        }
    }
}
