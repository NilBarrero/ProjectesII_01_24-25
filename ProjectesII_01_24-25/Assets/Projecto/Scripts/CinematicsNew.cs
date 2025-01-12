using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicsNew : MonoBehaviour
{
    [Header("Animation Settings")]
    public bool moveUp = true; // Controla si el objeto sube o baja
    public Vector3 targetPosition; // Posición final de la animación
    public float duration = 2f; // Duración de la animación en segundos

    private Vector3 initialPosition; // Posición inicial del objeto
    private Coroutine animationCoroutine; // Para manejar la animación en curso

    void Start()
    {
        // Guardar la posición inicial del objeto
        initialPosition = transform.position;
    }

    public void StartAnimation()
    {
        // Si hay una animación en curso, detenerla
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }

        // Comenzar una nueva animación
        animationCoroutine = StartCoroutine(AnimatePosition());
    }

    private IEnumerator AnimatePosition()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = moveUp ? targetPosition : initialPosition;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Interpolar entre la posición inicial y la final
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegurarse de que la posición final sea exacta
        transform.position = endPosition;
    }
}

