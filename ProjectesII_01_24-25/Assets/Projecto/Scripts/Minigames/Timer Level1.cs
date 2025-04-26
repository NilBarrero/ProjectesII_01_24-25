using UnityEngine;
using TMPro; // Importa la librer�a para usar TextMeshPro
using UnityEngine.SceneManagement;
using System.Collections;

public class TimerLevel1 : MonoBehaviour
{
    public int tiempoInicial = 30; // Tiempo inicial en segundos
    private int tiempoRestante;
    private float tiempoTranscurrido; // Temporizador en tiempo real
    public TextMeshProUGUI textoCuentaRegresiva; // Referencia al texto TextMeshPro donde mostrar�s la cuenta regresiva
    public string scene;

    // Variables para animaci�n y m�sica
    public Animator transitionAnimator;  // Referencia al Animator para la animaci�n
    public AudioSource musicSource;      // Referencia a la fuente de m�sica
    public float fadeOutDuration = 1f;   // Duraci�n del fade out de la m�sica

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

        // Cambiar color del texto basado en el tiempo restante
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

        // Iniciar la transici�n cuando el tiempo llega a 0
        if (tiempoRestante == 0)
        {
            StartCoroutine(TransitionToScene());
        }
    }

    private IEnumerator TransitionToScene()
    {
        // Inicia la animaci�n de transici�n
        transitionAnimator.SetTrigger("StartTransition"); // Aseg�rate de tener un trigger llamado "StartTransition" en tu Animator

        // Fade out de la m�sica
        float startVolume = musicSource.volume;
        float timeElapsed = 0f;

        while (timeElapsed < fadeOutDuration)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0f, timeElapsed / fadeOutDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Asegura que el volumen final sea 0
        musicSource.volume = 0f;

        // Espera el tiempo de la animaci�n antes de cambiar de escena
        yield return new WaitForSeconds(transitionAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Cargar la nueva escena
        SceneManager.LoadScene(scene);
    }

    void ActualizarTexto()
    {
        // Actualiza el texto de la cuenta regresiva en la UI usando TextMeshPro
        textoCuentaRegresiva.text = tiempoRestante.ToString() + " s";
    }
}

