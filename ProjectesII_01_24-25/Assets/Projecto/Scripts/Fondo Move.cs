using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMove : MonoBehaviour
{
    public float velocidad = 1f; // Velocidad base del fondo
    private float velocidadOriginal; // Almacena la velocidad original

    void Start()
    {
        velocidadOriginal = velocidad; // Guardar la velocidad inicial
    }

    void Update()
    {
        // Mover el fondo hacia la izquierda
        Vector2 movimiento = Vector2.left * velocidad * Time.deltaTime;
        transform.position = (Vector2)transform.position + movimiento;

        // Reiniciar la posición del fondo si sale de la vista
        if (transform.position.x <= -GetComponent<Renderer>().bounds.size.x)
        {
            transform.position += new Vector3(GetComponent<Renderer>().bounds.size.x * 2, 0, 0);
        }
    }

    // Método para aumentar la velocidad temporalmente
    public void AumentarVelocidadTemporal(float nuevaVelocidad, float duracion)
    {
        StopAllCoroutines(); // Detener cualquier cambio de velocidad en curso
        StartCoroutine(AumentarVelocidadCoroutine(nuevaVelocidad, duracion));
    }

    private IEnumerator AumentarVelocidadCoroutine(float nuevaVelocidad, float duracion)
    {
        velocidad = nuevaVelocidad; // Aumentar la velocidad
        yield return new WaitForSeconds(duracion); // Esperar el tiempo especificado
        velocidad = velocidadOriginal; // Restaurar la velocidad original
    }
}
