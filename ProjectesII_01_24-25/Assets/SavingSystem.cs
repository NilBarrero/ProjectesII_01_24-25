using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavingSystem : MonoBehaviour
{
    SceneVisitor visitor;
    public int sceneNumber;  // Número de la escena
    bool visited;  // Indicador si la escena fue visitada
    public Image image;  // Imagen que muestra el estado de la escena

    private void OnEnable()
    {
        // Mostrar los valores de 'visitor.sceneNumber' y 'sceneNumber' para depuración
        Debug.Log("visitor.sceneNumber: " + visitor.sceneNumber);
        Debug.Log("sceneNumber: " + sceneNumber);

        // Comprobar si el número de escena del visitante coincide con el número de la escena
        if (visitor.sceneNumber == sceneNumber)
        {
            // Si el visitante está en esta escena y ya fue visitada, pinta de rojo, si no, de negro
            image.color = visited ? Color.red : Color.black;
            Debug.Log("Pintando de rojo");  // Depuración: Ver si está entrando en esta condición
        }
        else
        {
            // Si no está en esta escena, y fue visitada, pinta de verde, si no, de negro
            image.color = visited ? Color.green : Color.black;
            Debug.Log("Pintando de verde");  // Depuración: Ver si está entrando en esta condición
        }
    }


}
