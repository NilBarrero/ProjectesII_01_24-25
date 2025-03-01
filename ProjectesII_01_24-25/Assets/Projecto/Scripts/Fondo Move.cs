using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class FondoMove : MonoBehaviour
{
    public float velocidad = 1f; // Velocidad base
    public float velAccelerate = 3f; // Velocidad de aceleración
    public float time = 0.5f; // Tiempo de aceleración
    private float velocidadOriginal; // Velocidad original
    public bool huirMinigame = false; // Si se activa el mini juego
    public Pressed pressed;

    private bool isSpeedingUp = false; // Para asegurar que solo haya un cambio de velocidad a la vez

    void Start()
    {
        velocidadOriginal = velocidad; // Guardar la velocidad inicial
    }

    void Update()
    {
        // Mover el fondo hacia la izquierda usando la velocidad
        Vector2 movimiento = Vector2.left * velocidad * Time.deltaTime;
        transform.position = (Vector2)transform.position + movimiento;

        // Si está en el mini juego y la aceleración no está activada, aceleramos
        if (huirMinigame && !isSpeedingUp)
        {
            AumentarVelocidadTemporal(velAccelerate, time);
        }
        if (pressed.haSidoPulsado)
            StartCoroutine(AumentarVelocidadCoroutine(velAccelerate, time));
        // Reiniciar la posición del fondo si sale de la vista
        if (transform.position.x <= -GetComponent<Renderer>().bounds.size.x)
        {
           
            transform.position += new Vector3(GetComponent<Renderer>().bounds.size.x * 2, 0, 0);
        }
    }

    // Método para aumentar la velocidad temporalmente
    public void AumentarVelocidadTemporal(float nuevaVelocidad, float duracion)
    {
        if (isSpeedingUp) return; // Evitar cambiar la velocidad si ya está en proceso de aceleración

        isSpeedingUp = true; // Indica que estamos acelerando
        StopAllCoroutines(); // Detener cualquier coroutine previa
        StartCoroutine(AumentarVelocidadCoroutine(nuevaVelocidad, duracion)); // Iniciar la coroutine para aumentar la velocidad
    }

    private IEnumerator AumentarVelocidadCoroutine(float nuevaVelocidad, float duracion)
    {
        velocidad = nuevaVelocidad; // Cambiar a la nueva velocidad de aceleración
        yield return new WaitForSeconds(duracion); // Esperar el tiempo de aceleración
        velocidad = velocidadOriginal; // Restaurar la velocidad original}
    }
}
