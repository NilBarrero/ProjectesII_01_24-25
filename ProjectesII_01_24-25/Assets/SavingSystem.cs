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
    public GameObject text;

    void Start()
    {
        // Asegurarse de que el TextMeshPro esté desactivado al principio
        
            text.SetActive(false);

        if (sceneNumber == SceneManager.GetActiveScene().buildIndex || visited)
        {
            text.SetActive(true);
        }
        
    }

    private void OnEnable()
    {
        // Obtener si la escena fue visitada previamente desde PlayerPrefs
        int visitedNumber = PlayerPrefs.GetInt("Scene" + sceneNumber, 0);
        visited = visitedNumber > 0;

        // Obtener el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Verificar si este nodo representa la escena actual
        if (sceneNumber == currentSceneIndex)
        {
            // Marcar la escena actual en rojo
            if (image != null)
            {
                image.color = Color.red;
                
            }
            else
            {
                Debug.LogWarning("La imagen no está asignada en el Inspector.");
            }
        }
        else
        {
           

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


}