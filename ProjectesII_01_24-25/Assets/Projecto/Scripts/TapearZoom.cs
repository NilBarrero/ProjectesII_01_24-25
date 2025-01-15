using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapearZoom : MonoBehaviour
{
    public float zoomSpeed = 0.1f; // Velocidad a la que la cámara hace zoom
    public float minZoom = 1f; // Mínimo tamaño del zoom permitido
    public float zoomDuration = 10f; // Tiempo total para completar el zoom

    private float zoomTimer = 0f; // Temporizador para medir el tiempo
    private bool isZooming = true; // Controla si el zoom está activo

    void Update()
    {
        if (isZooming)
        {
            zoomTimer += Time.deltaTime;

            // Calcula el tamaño del zoom progresivamente
            Camera.main.orthographicSize -= zoomSpeed * Time.deltaTime;

            // Limita el zoom al mínimo permitido
            if (Camera.main.orthographicSize <= minZoom)
            {
                Camera.main.orthographicSize = minZoom;
                isZooming = false; // Detiene el zoom cuando alcanza el mínimo
            }
        }
    }
}

