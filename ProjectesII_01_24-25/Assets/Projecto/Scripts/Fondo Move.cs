using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMove : MonoBehaviour
{
    public float velocidad;  // Velocidad a la que se mueve el fondo
    private Vector2 puntoInicio;

    void Start()
    {
        // Guardamos la posición inicial del fondo en 2D
        puntoInicio = transform.position;
    }

    void Update()
    {
        // Mover el fondo hacia la izquierda de manera constante
        Vector2 movimiento = Vector2.left * velocidad * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0) + new Vector3(movimiento.x, movimiento.y, 0);

        // Comprobar si el fondo ha salido completamente de la vista
        if (transform.position.x <= puntoInicio.x - GetComponent<Renderer>().bounds.size.x)
        {
            // Reiniciar la posición del fondo a la derecha
            transform.position = new Vector3(puntoInicio.x, puntoInicio.y, 0);
        }
    }
}
