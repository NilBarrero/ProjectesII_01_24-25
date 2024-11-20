using UnityEngine;
using TMPro; // Importa la librería para usar TextMeshPro
using UnityEngine.SceneManagement;

public class CuentaRegresiva : MonoBehaviour
{
    public int tiempoInicial = 30; // Tiempo inicial en segundos
    private int tiempoRestante;
    private float tiempoTranscurrido; // Temporizador en tiempo real
    public TextMeshProUGUI textoCuentaRegresiva; // Referencia al texto TextMeshPro donde mostrarás la cuenta regresiva

    void Start()
    {
        tiempoRestante = tiempoInicial; // Establecemos el tiempo restante al valor inicial
        tiempoTranscurrido = 0f; // Inicializamos el temporizador
        ActualizarTexto(); // Actualizamos el texto al inicio
    }

    void Update()
    {
        // Solo restamos cuando haya pasado 1 segundo real
        if (tiempoRestante > 0)
        {
            tiempoTranscurrido += Time.deltaTime; // Aumenta el contador con el tiempo del último fotograma

            if (tiempoTranscurrido >= 1f) // Si ha pasado 1 segundo real
            {
                tiempoRestante--; // Restamos un segundo
                tiempoTranscurrido = 0f; // Reseteamos el temporizador
                ActualizarTexto(); // Actualizamos el texto
            }
        }
        else if (tiempoRestante == 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    void ActualizarTexto()
    {
        // Actualiza el texto de la cuenta regresiva en la UI usando TextMeshPro
        textoCuentaRegresiva.text = tiempoRestante.ToString() + " s";
    }
}

