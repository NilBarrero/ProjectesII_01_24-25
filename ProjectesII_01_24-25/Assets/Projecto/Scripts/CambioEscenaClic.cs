using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaClic : MonoBehaviour
{
    public int clicksRequired = 5; // Número de clics necesarios para cambiar la escena
    public string sceneToLoad;

    private int clickCount = 0; // Contador de clics

    void OnMouseDown()
    {
        clickCount++; // Aumenta el contador al hacer clic

        if (clickCount >= clicksRequired)
        {
            SceneManager.LoadScene(sceneToLoad); // Cambia de escena cuando alcanza el límite
        }
    }
}
