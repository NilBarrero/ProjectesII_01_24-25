using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndDespawn : MonoBehaviour
{
    public Transform[] A_B;
    public float spawnDelay = 0.02f;
    private float timer = 0f;
    private int actualPosition = 0;
    public float newSpeed;
    public float changeSpeed;

    private Rigidbody2D rb;
    private FondoMove fondoMove; // Referencia al script del fondo

    void Start()
    {
        if (A_B == null || A_B.Length == 0)
        {
            Debug.LogError("A_B no está asignado o está vacío.");
            enabled = false;
            return;
        }

        rb = GetComponent<Rigidbody2D>();
        fondoMove = FindObjectOfType<FondoMove>(); // Encontrar automáticamente el script del fondo
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnDelay)
        {
            // Generar una posición aleatoria diferente a la actual
            int num;
            do
            {
                num = Random.Range(0, A_B.Length);
            } while (num == actualPosition);

            actualPosition = num;

            // Mover el objeto usando Rigidbody2D
            rb.position = A_B[num].position;

            // Reinicia el temporizador
            timer = 0f;
        }
    }

    // Detectar cuando el objeto es pulsado
    private void OnMouseDown()
    {
        Debug.Log("Objeto pulsado");

        if (fondoMove != null)
        {
            // Aumentar temporalmente la velocidad del fondo
            fondoMove.AumentarVelocidadTemporal(newSpeed, changeSpeed); // Cambiar a velocidad 5 durante 1 segundo
        }
        else
        {
            Debug.LogWarning("No se encontró el script FondoMove.");
        }
    }
}
