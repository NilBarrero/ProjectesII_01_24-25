using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavingSystem : MonoBehaviour
{
    public int sceneNumber;  // N�mero de la escena
    bool visited;  // Indicador si la escena fue visitada
    public Image image;  // Imagen que muestra el estado de la escena

    private void OnEnable()
    {
        // Obtener si la escena fue visitada previamente desde PlayerPrefs
        int visitedNumber = PlayerPrefs.GetInt("Scene" + sceneNumber, 0);
        visited = visitedNumber > 0;

        // Cambiar el color de la imagen seg�n si la escena fue visitada o no
        if (image != null)  // Verificar si 'image' no es nulo
        {
            image.color = visited ? Color.green : Color.black;
        }
        else
        {
            Debug.LogWarning("La imagen no est� asignada en el Inspector.");
        }
    }

    public void LoadScene()
    {
        if (visited)
        {
            // Cargar la escena solo si ha sido visitada
            SceneManager.LoadScene(sceneNumber);
        }
        else
        {
            Debug.LogWarning("La escena no ha sido visitada a�n.");
        }
    }
}
