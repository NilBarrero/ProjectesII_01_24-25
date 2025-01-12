using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicsNew : MonoBehaviour
{
    [Header("Animation Settings")]
    public bool moveUp = true; // Controla si el objeto sube o baja
    public Vector3 targetPosition; // Posici�n final de la animaci�n
    public float duration = 2f; // Duraci�n de la animaci�n en segundos

    private Vector3 initialPosition; // Posici�n inicial del objeto
    private Coroutine animationCoroutine; // Para manejar la animaci�n en curso

    void Start()
    {
        // Guardar la posici�n inicial del objeto
        initialPosition = transform.position;
    }

    public void StartAnimation()
    {
        // Si hay una animaci�n en curso, detenerla
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }

        // Comenzar una nueva animaci�n
        animationCoroutine = StartCoroutine(AnimatePosition());
    }

    private IEnumerator AnimatePosition()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = moveUp ? targetPosition : initialPosition;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Interpolar entre la posici�n inicial y la final
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegurarse de que la posici�n final sea exacta
        transform.position = endPosition;
    }
}

