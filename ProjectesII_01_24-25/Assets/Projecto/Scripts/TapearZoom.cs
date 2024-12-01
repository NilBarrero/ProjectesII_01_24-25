using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapearZoom : MonoBehaviour
{
    public int counter = 0;
    public int max = 30; // Número máximo de clics antes de cambiar de escena
    public string scene; // Nombre de la escena a cargar
    public float zoomStep = 0.5f; // Cantidad de zoom a aplicar en cada iteración

    void Update()
    {
        if (counter >= max)
        {
            SceneManager.LoadScene(scene);
        }
    }

    private void OnMouseDown()
    {
        counter++;

        // Cada 5 clics, ajusta el zoom
        if (counter % 5 == 0)
        {
            Camera.main.orthographicSize -= zoomStep;

            // Asegúrate de que el zoom no sea demasiado pequeño
            if (Camera.main.orthographicSize < 1)
            {
                Camera.main.orthographicSize = 1;
            }
        }
    }
}
