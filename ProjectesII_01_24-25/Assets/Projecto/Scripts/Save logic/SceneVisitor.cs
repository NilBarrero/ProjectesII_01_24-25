using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneVisitor : MonoBehaviour
{
    public int sceneNumber;  // Este valor se debe establecer dependiendo de la escena en la que est�s.

    private void OnEnable()
    {
        Debug.Log("Guardando escena: " + sceneNumber);
        PlayerPrefs.SetInt("Scene" + sceneNumber, 1);  // Guarda una marca para la escena
        PlayerPrefs.SetInt("LastScene", sceneNumber);  // Guarda el n�mero de la �ltima escena
        PlayerPrefs.Save();  // Guarda los cambios inmediatamente
    }
}

