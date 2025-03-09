using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavingSystem : MonoBehaviour
{
    SceneVisitor visitor;
    public int sceneNumber;  // N�mero de la escena
    bool visited;  // Indicador si la escena fue visitada
    public Image image;  // Imagen que muestra el estado de la escena

    private void OnEnable()
    {
        // Mostrar los valores de 'visitor.sceneNumber' y 'sceneNumber' para depuraci�n
        Debug.Log("visitor.sceneNumber: " + visitor.sceneNumber);
        Debug.Log("sceneNumber: " + sceneNumber);

        // Comprobar si el n�mero de escena del visitante coincide con el n�mero de la escena
        if (visitor.sceneNumber == sceneNumber)
        {
            // Si el visitante est� en esta escena y ya fue visitada, pinta de rojo, si no, de negro
            image.color = visited ? Color.red : Color.black;
            Debug.Log("Pintando de rojo");  // Depuraci�n: Ver si est� entrando en esta condici�n
        }
        else
        {
            // Si no est� en esta escena, y fue visitada, pinta de verde, si no, de negro
            image.color = visited ? Color.green : Color.black;
            Debug.Log("Pintando de verde");  // Depuraci�n: Ver si est� entrando en esta condici�n
        }
    }


}
