using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavingSystem : MonoBehaviour
{
    public int sceneNumber;  // Número de la escena
    bool visited;  // Indicador si la escena fue visitada
    public Image image;  // Imagen que muestra el estado de la escena

    private void OnEnable()
    {
        // Obtener si la escena fue visitada previamente desde PlayerPrefs
        int visitedNumber = PlayerPrefs.GetInt("Scene" + sceneNumber, 0);
        visited = visitedNumber > 0;

        // Cambiar el color de la imagen según si la escena fue visitada o no
        if (image != null)  // Verificar si 'image' no es nulo
        {
            image.color = visited ? Color.green : Color.black;
        }
        else
        {
            Debug.LogWarning("La imagen no está asignada en el Inspector.");
        }
    }


}