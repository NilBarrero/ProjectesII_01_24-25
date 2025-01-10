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

            ship.transform.position = new Vector3(speedMov * Time.deltaTime, 0f, 0f);

            if (Vector3.Distance(transform.position, A_B[next].position) < minDistance)
            {
                next += 1;
                if (next >= A_B.Length)
                {
                    if (teleport == true)
                    {
                        transform.position = A_B[0].position;
                        next = 1;
                    }
                    else
                        next = 0;
                }
                
            }
        }
        if (maxCount == contador)
        {
            SceneManager.LoadScene(scene);
        }
        // Después de procesar el evento, reiniciamos el estado de pulsado
        botonPulsado.haSidoPulsado = false; // Reiniciamos el estado de pulsado
    }
}

