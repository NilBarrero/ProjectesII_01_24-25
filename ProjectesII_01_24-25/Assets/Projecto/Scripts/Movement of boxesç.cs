using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementofboxes : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento
    public float intervaloCambio = 1f; // Intervalo en el que cambia la dirección

    private Vector2 direccionObjetivo;
    private float timer;
    public Camera camara;  // La cámara que está mostrando la escena

    void Start()
    {
        // Genera una dirección aleatoria inicial en 2D
        direccionObjetivo = Random.insideUnitCircle; // Genera un vector aleatorio dentro de un círculo unitario (2D)

        // Si no se ha asignado una cámara, usa la cámara principal
        if (camara == null)
            camara = Camera.main;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= intervaloCambio)
        {
            // Cambiar la dirección aleatoriamente en 2D
            direccionObjetivo = Random.insideUnitCircle;
            timer = 0f;
        }

        // Mover el objeto en la dirección objetivo en 2D
        transform.Translate(direccionObjetivo * velocidad * Time.deltaTime);

        // Limitar el movimiento dentro de los márgenes de la cámara
        LimitarPosicionEnPantalla();
    }

    void LimitarPosicionEnPantalla()
    {
        // Convertir la posición mundial del objeto a coordenadas del viewport (0-1)
        Vector3 posicionViewport = camara.WorldToViewportPoint(transform.position);

        // Limitar la posición en el eje X (0 a 1)
        posicionViewport.x = Mathf.Clamp(posicionViewport.x, 0f, 1f);

        // Limitar la posición en el eje Y (0 a 1)
        posicionViewport.y = Mathf.Clamp(posicionViewport.y, 0f, 1f);

        // Convertir de vuelta a las coordenadas del mundo
        transform.position = camara.ViewportToWorldPoint(posicionViewport);
    }
}
