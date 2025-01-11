using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    public ParticleSystem particles;
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    private Vector3 startMousePosition;
    private Vector3 currentMousePosition;
    private bool moved = false;
    private float holdTime = 0f; // Tiempo que el rat�n ha estado quieto
    private float timeThreshold = 0.2f; // Umbral de tiempo para considerar que el rat�n estuvo quieto

    private Rigidbody2D rb;

    private void Start()
    {
        // Aseguramos que el objeto tenga un Rigidbody2D para aplicar la f�sica
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Este objeto necesita tener un Rigidbody2D para aplicar f�sica.");
        }
    }

    private void Update()
    {
        // Si el objeto est� siendo arrastrado
        if (isBeingHeld)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);

            // Solo iniciar las part�culas si no est�n ya activas
            if (!particles.isPlaying)
            {
                particles.Play();
            }

            // Comprobamos si el rat�n se movi�
            currentMousePosition = mousePos;
            if (Vector3.Distance(currentMousePosition, startMousePosition) > 0.1f) // Umbral para detectar movimiento
            {
                moved = true;
                holdTime = 0f; // Reseteamos el temporizador si se mueve
            }
            else
            {
                // Si el rat�n no se mueve, aumentamos el temporizador
                holdTime += Time.deltaTime;

                // Si el rat�n ha estado quieto durante m�s del umbral, actualizamos la posici�n inicial
                if (holdTime >= timeThreshold)
                {
                    startMousePosition = currentMousePosition;
                    holdTime = 0f; // Reiniciamos el temporizador
                }
            }
        }
        else
        {
            // Detener las part�culas si no se est� arrastrando
            particles.Stop();
        }
    }

    private void OnMouseDown()
    {
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




