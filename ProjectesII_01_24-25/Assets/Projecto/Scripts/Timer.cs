using UnityEngine;
using TMPro; // Importa la librería para usar TextMeshPro
using UnityEngine.SceneManagement;

public class CuentaRegresiva : MonoBehaviour
{
    public int tiempoInicial = 30; // Tiempo inicial en segundos
    private int tiempoRestante;
    private float tiempoTranscurrido; // Temporizador en tiempo real
    public TextMeshProUGUI textoCuentaRegresiva; // Referencia al texto TextMeshPro donde mostrarás la cuenta regresiva
    public GameObject life0;
    public GameObject life1;
    public GameObject life2;

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

        if (tiempoRestante > 7)
        {
            textoCuentaRegresiva.color = Color.green;
        }
        else if (tiempoRestante <= 7 && tiempoRestante > 3)
        {
            textoCuentaRegresiva.color = Color.yellow;
        }
        else if (tiempoRestante <= 3)
        {
            textoCuentaRegresiva.color = Color.red;
        }

        if (tiempoRestante == 0)
        {
            if (Transition.lifes == 3)
            {
                Transition.lifes--;
                life0.SetActive(false);
            }
            else if (Transition.lifes == 2)
            {
                Transition.lifes--;
                life1.SetActive(false);
            }
            else if (Transition.lifes == 1)
            {
                Transition.lifes--;
                life2.SetActive(false);
            }
            else
            {
                SceneManager.LoadScene("LoseScene");
            }
            SceneManager.LoadScene("Transition Scene");
        }
    }

    void ActualizarTexto()
    {
        // Actualiza el texto de la cuenta regresiva en la UI usando TextMeshPro
        textoCuentaRegresiva.text = tiempoRestante.ToString() + " s";
    }
}
