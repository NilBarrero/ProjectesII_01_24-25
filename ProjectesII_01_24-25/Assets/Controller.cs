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

    // Este método es llamado cuando un GameObject ha sido pulsado
    public void ObjetoPulsado(Pressed botonPulsado)
    {
        // Si el objeto ha sido pulsado, sumamos 1 al contador
        if (botonPulsado.haSidoPulsado)
        {
            contador++; // Incrementamos el contador

            //transform.position = Vector2.MoveTowards(transform.position, A_B[next].position, speedMov * Time.deltaTime);

            transform.position = A_B[contador].position;

        }
        if (maxCount == contador)
        {
            SceneManager.LoadScene(scene);
        }
        // Después de procesar el evento, reiniciamos el estado de pulsado
        botonPulsado.haSidoPulsado = false; // Reiniciamos el estado de pulsado
    }
}

