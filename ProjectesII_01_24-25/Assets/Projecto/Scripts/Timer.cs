using UnityEngine;
using TMPro; // Importa la librer�a para usar TextMeshPro
using UnityEngine.SceneManagement;

public class CuentaRegresiva : MonoBehaviour
{
    public int tiempoInicial = 30; // Tiempo inicial en segundos
    public int tiempoRestante;
    public float tiempoTranscurrido; // Temporizador en tiempo real
    public TextMeshProUGUI textoCuentaRegresiva; // Referencia al texto TextMeshPro donde mostrar�s la cuenta regresiva
    public GameObject life0;
    public GameObject life1;
    public GameObject life2;
    public string scene;
    public bool destroyTrash = false;
    public GameManagercounter counter;

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
            tiempoTranscurrido += Time.deltaTime; // Aumenta el contador con el tiempo del �ltimo fotograma

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
       
        if (tiempoRestante == 0 && !destroyTrash)
        {
            SceneManager.LoadScene(scene);
        }
        if (tiempoRestante == 0 && destroyTrash && counter.clickCount < counter.maxCount && counter.clickCount > counter.maxCount)
        {
            SceneManager.LoadScene(scene);
        }
        else if (tiempoRestante <= 7 && tiempoRestante > 3)
        {
            textoCuentaRegresiva.color = Color.yellow;
        }
        else if (tiempoRestante <= 3)
        {
            textoCuentaRegresiva.color = Color.red;
        }

       
    }

    void ActualizarTexto()
    {
        // Actualiza el texto de la cuenta regresiva en la UI usando TextMeshPro
        textoCuentaRegresiva.text = tiempoRestante.ToString() + " s";
    }
}
