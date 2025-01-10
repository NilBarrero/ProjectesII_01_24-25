using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.AxisState;

public class Controller : MonoBehaviour
{
    // Contador que se incrementa cuando un objeto es pulsado
    public int contador = 0;
    public int maxCount = 5;
    public string scene;
    public GameObject ship;


    public float speedMov;
    public Transform[] A_B;
    public float minDistance;
    public bool teleport = false;
    private int next = 0;

    void Start()
    {
        if (A_B == null || A_B.Length == 0)
        {
            Debug.LogError("A_B no está asignado o está vacío.");
        }

        if (ship == null)
        {
            Debug.LogError("El ship no está asignado.");
        }
    }

    // Este método es llamado cuando un GameObject ha sido pulsado
    public void ObjetoPulsado(Pressed botonPulsado)
    {
        if (!botonPulsado.haSidoPulsado)
        {
            Debug.LogError("BBBBBBBBBBBBBBBBBBBBBB");
        }
        if (botonPulsado.haSidoPulsado)
        {
            contador++; // Incrementamos el contador

            // Aseguramos que el contador no se salga del rango del array A_B
            if (contador < A_B.Length)
            {
                transform.position = A_B[contador].position;
            }
            else
            {
                // Si contador excede el tamaño del array, lo reseteamos o lo ajustamos a un valor válido.
                contador = 0;
                transform.position = A_B[contador].position;
            }
        }

        if (maxCount == contador)
        {
            SceneManager.LoadScene(scene);
        }

        botonPulsado.haSidoPulsado = false; // Reiniciamos el estado de pulsado
    }
}

