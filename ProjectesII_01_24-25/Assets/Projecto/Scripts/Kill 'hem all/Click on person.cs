using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickonperson : MonoBehaviour
{
    public SpawnAndDespawn spawnAndDespawn;
    private GameManagercounter gameManager;
    private BoxCollider2D boxCollider; // Referencia al BoxCollider2D

    public float rotationSpeed = 100f; // Velocidad de rotación
    public float rotation = -90f;
    private bool isRotating = false; // Para saber si el objeto está rotando
    public bool destroy = false;
    public ParticleSystem destroyParticles;
    public bool isArrow = false;
    public float despawnTime = .5f;

    public AudioSource clickAudioSource; // Referencia al AudioSource

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

        if (clickAudioSource == null)
        {
            Debug.LogWarning("No se asignó un AudioSource para el clic. Asegúrate de asignarlo en el Inspector.");
        }

        destroyParticles.Stop();
    }

    void OnMouseDown()
    {
        // Reproducir el sonido de clic
        if (clickAudioSource != null)
        {
            clickAudioSource.Stop(); // Detener cualquier sonido en reproducción
            clickAudioSource.Play(); // Reproducir el sonido nuevamente
        }

        // Verificar que el GameManager y el BoxCollider2D existan
        if (gameManager != null && boxCollider != null && !destroy)
        {
            // Incrementar el contador de clics en el GameManager
            gameManager.IncrementClickCount();

            // Llamar al método para iniciar la rotación
            RotateToTargetAngle();

            // Desactivar el BoxCollider2D para que no pueda ser clickeado de nuevo
            boxCollider.enabled = false;
        }

        if (gameManager != null && boxCollider != null && destroy && !isArrow)
        {
            // Incrementar el contador de clics en el GameManager
            gameManager.IncrementClickCount();

            Destroy(gameObject);
            destroyParticles.Play();
        }
    }

    void RotateToTargetAngle()
    {
        // Iniciar la rotación hacia -90 grados en Z
        isRotating = true;
    }

    void Update()
    {
        // Si estamos rotando el objeto hacia -90 grados
        if (isRotating)
        {
            // Rotar el objeto de forma gradual hacia -90 grados
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, rotation, rotationSpeed * Time.deltaTime);

            // Aplicar la nueva rotación al objeto
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            // Detener la rotación cuando llegue a -90 grados
            if (Mathf.Approximately(angle, rotation))
            {
                isRotating = false; // Dejar de rotar
            }
        }
    }
}
