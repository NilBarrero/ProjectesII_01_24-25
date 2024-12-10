using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickonperson : MonoBehaviour
{
    private GameManagercounter gameManager;
    private BoxCollider2D boxCollider;  // Referencia al BoxCollider2D

    public float rotationSpeed = 100f;  // Velocidad de rotaci�n
    public float rotation = -90f;
    private bool isRotating = false;  // Para saber si el objeto est� rotando

    void Start()
    {
        // Obtener el GameManager
        gameManager = FindObjectOfType<GameManagercounter>();

        // Obtener el BoxCollider2D
        boxCollider = GetComponent<BoxCollider2D>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager no encontrado en la escena");
        }

        if (boxCollider == null)
        {
            Debug.LogError("Este objeto no tiene un BoxCollider2D");
        }
    }

    void OnMouseDown()
    {
        // Verificar que el GameManager y el BoxCollider2D existan
        if (gameManager != null && boxCollider != null)
        {
            // Incrementar el contador de clics en el GameManager
            gameManager.IncrementClickCount();

            // Llamar al m�todo para iniciar la rotaci�n
            RotateToTargetAngle();

            // Desactivar el BoxCollider2D para que no pueda ser clickeado de nuevo
            boxCollider.enabled = false;
        }
    }

    void RotateToTargetAngle()
    {
        // Iniciar la rotaci�n hacia -90 grados en Z
        isRotating = true;
    }

    void Update()
    {
        // Si estamos rotando el objeto hacia -90 grados
        if (isRotating)
        {
            // Rotar el objeto de forma gradual hacia -90 grados
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, rotation, rotationSpeed * Time.deltaTime);

            // Aplicar la nueva rotaci�n al objeto
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            // Detener la rotaci�n cuando llegue a -90 grados
            if (Mathf.Approximately(angle, rotation))
            {
                isRotating = false;  // Dejar de rotar
            }
        }
    }
}
