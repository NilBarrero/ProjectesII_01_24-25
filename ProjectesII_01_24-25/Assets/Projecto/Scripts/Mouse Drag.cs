using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    public ParticleSystem particles;
    private float startPosX;
    private float startPosY;
    public bool isBeingHeld = false;
    private Vector3 startMousePosition;
    private Vector3 currentMousePosition;
    private bool moved = false;
    private float holdTime = 0f; // Tiempo que el rat�n ha estado quieto
    private float updateThreshold = 0.5f; // Tiempo para actualizar la posici�n inicial del rat�n
    private float moveThreshold = 0.1f; // Umbral para detectar movimiento

    private Rigidbody2D rb;

    private Vector3 lastMousePosition;  // �ltima posici�n del rat�n
    private float speedThreshold = 0.01f; // Umbral de velocidad para considerar que el rat�n se movi� (ajustable)

    private float additionalHoldTime = 0f; // Nuevo temporizador adicional
    private float additionalTimeThreshold = 1f; // Umbral para el nuevo temporizador (por ejemplo, 1 segundo)

    public DetectPrefab detectPrefab;
    public bool isCollisionLocked = false;

    private void Start()
    {
        // Aseguramos que el objeto tenga un Rigidbody2D para aplicar la f�sica
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Este objeto necesita tener un Rigidbody2D para aplicar f�sica.");
        }

        // Inicializamos la �ltima posici�n del rat�n
        lastMousePosition = Input.mousePosition;
    }

    private void Update()
    {
        if (isCollisionLocked) return;
        // Si el objeto est� siendo arrastrado
        if (isBeingHeld)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            // Raycast desde el rat�n para detectar si colisiona con algo
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                // Si el raycast golpea un collider, no permitimos que el objeto atraviese el collider.
                // Aqu� puedes comprobar que el collider no es el del objeto arrastrado
                if (hit.collider.CompareTag("Blocker")) // Si el collider es el que bloquea el movimiento
                {
                    // Evitar que el objeto atraviese el collider
                    return; // Simplemente salir sin mover el objeto.
                }
            }

            // Si el raycast no golpea nada o no es un collider que bloquea el movimiento:
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);

            // Solo iniciar las part�culas si no est�n ya activas
            if (!particles.isPlaying)
            {
                particles.Play();
            }

            // Verificar si el rat�n se movi�
            currentMousePosition = mousePos;
            if (Vector3.Distance(currentMousePosition, startMousePosition) > moveThreshold) // Umbral para detectar movimiento
            {
                moved = true;
                holdTime = 0f; // Reseteamos el temporizador si se mueve
            }
            else
            {
                // Si el rat�n no se mueve, aumentamos el temporizador
                holdTime += Time.deltaTime;

                // Si el rat�n ha estado quieto durante m�s del umbral, actualizamos la posici�n inicial
                if (holdTime >= updateThreshold)
                {
                    startMousePosition = currentMousePosition;
                    holdTime = 0f; // Reiniciamos el temporizador
                }
            }

            // Incrementamos el nuevo temporizador adicional
            additionalHoldTime += Time.deltaTime;

            // Si el temporizador adicional ha alcanzado el umbral, ejecutamos alguna acci�n
            if (additionalHoldTime >= additionalTimeThreshold)
            {
                // Aqu� puedes hacer lo que necesites con el temporizador adicional
                Debug.Log("Temporizador adicional alcanzado: " + additionalHoldTime);

                // Reiniciamos el temporizador adicional
                additionalHoldTime = 0f;
            }

            // Comprobamos la velocidad del rat�n
            Vector3 mouseVelocity = (mousePos - lastMousePosition) / Time.deltaTime;

            // Si la velocidad es cero o menor que el umbral, no se mueve
            if (mouseVelocity.magnitude <= speedThreshold)
            {
                moved = false;  // No se movi� con suficiente velocidad
                startMousePosition = mousePos;
            }

            // Actualizamos la �ltima posici�n del rat�n
            lastMousePosition = mousePos;
        }
        else
        {
            // Detener las part�culas si no se est� arrastrando
            particles.Stop();
        }
    }

    private void OnMouseDown()
    {
        if (isCollisionLocked) return;

        // Detecta si el rat�n ha sido presionado
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            startMousePosition = mousePos;

            isBeingHeld = true;

            // Inicia las part�culas directamente al presionar el rat�n
            particles.Play();

            // Reiniciamos el estado de "moved"
            moved = false;
            holdTime = 0f; // Reiniciamos el temporizador
        }
    }

    private void OnMouseUp()
    {
        // Cuando el rat�n se suelta, detenemos el arrastre
        isBeingHeld = false;

        // Solo aplicar la fuerza si el rat�n se movi�
        if (moved)
        {
            // Calcula la direcci�n y la magnitud del lanzamiento
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            // Calcula la direcci�n entre la posici�n de inicio y la posici�n de liberaci�n
            Vector3 dragDirection = mousePos - startMousePosition;

            // Aplica la velocidad al objeto en funci�n de la distancia arrastrada
            ApplyLaunchForce(dragDirection);
        }
        else
        {
            // Si el rat�n no se movi� lo suficiente (o est� detenido), el objeto caer� sin fuerza
            rb.velocity = Vector2.zero;  // Detenemos cualquier velocidad previa
        }

        // Detener las part�culas de forma limpia
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    private void ApplyLaunchForce(Vector3 dragDirection)
    {
        // Normalizamos la direcci�n para que la magnitud de la fuerza no dependa de la direcci�n
        Vector3 launchVelocity = dragDirection.normalized * 10f; // "10f" controla la fuerza del lanzamiento

        // Aplicamos la velocidad al Rigidbody2D
        rb.velocity = launchVelocity;
    }
}

