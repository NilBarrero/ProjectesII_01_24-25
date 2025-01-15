using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RockPaperScissors : MonoBehaviour
{
    public int rival; // Elección del rival (1 = Piedra, 2 = Papel, 3 = Tijera)
    public int player; // Elección del jugador (1 = Piedra, 2 = Papel, 3 = Tijera)
    public int puntuacionRival; // Puntuación del rival
    public int puntuacionPlayer; // Puntuación del jugador
    public float change;
    public string scene1;
    public string scene2;
    public GameObject text1;
    public GameObject text2;
    public float time;

    private float playerTimer = 0.0f; // Temporizador para alternar la elección del jugador

    // Variables para animación y música
    public Animator transitionAnimator;  // Referencia al Animator para la animación
    public AudioSource musicSource;      // Referencia a la fuente de música
    public float fadeOutDuration = 1f;   // Duración del fade out de la música

    void Start()
    {
        ResetRival();
        text1.SetActive(false);
        text2.SetActive(false);
    }

    void Update()
    {
        // Alterna la elección del jugador cada 0.9 segundos
        playerTimer += Time.deltaTime;
        if (playerTimer >= change)
        {
            player = (player % 3) + 1; // Alterna entre 1, 2 y 3
            playerTimer = 0.0f;
        }
    }

    // Detecta el clic en el objeto
    void OnMouseDown()
    {
        // Compara las elecciones y actualiza las puntuaciones
        if (player == rival)
        {
            Debug.Log("Empate");
        }
        else if ((player == 1 && rival == 3) || (player == 2 && rival == 1) || (player == 3 && rival == 2))
        {
            Debug.Log("Jugador gana");
            puntuacionPlayer++;
            change -= 0.1f;
            text1.SetActive(true);
            StartCoroutine(Desactive(time));

        }
        else
        {
            Debug.Log("Rival gana");
            puntuacionRival++;
            change += 0.1f;
            text2.SetActive(true);
            StartCoroutine(Desactive(time));
        }

        // Reinicia la elección del rival
        ResetRival();

        // Verifica si alguien ha ganado
        if (puntuacionPlayer > 2)
        {
            Debug.Log("¡Jugador gana la partida!");
            StartCoroutine(TransitionToScene(scene1));
        }
        else if (puntuacionRival > 2)
        {
            Debug.Log("¡Rival gana la partida!");
            StartCoroutine(TransitionToScene(scene2));
        }

        IEnumerator Desactive(float time)
        {
            yield return new WaitForSeconds(time);
            text1.SetActive(false);
            text2.SetActive(false);
        }
    }

    // Corutina para manejar la transición de escena
    private IEnumerator TransitionToScene(string sceneName)
    {
        // Inicia la animación de transición
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("StartTransition"); // Asegúrate de tener un trigger llamado "StartTransition"
        }

        // Fade out de la música
        if (musicSource != null)
        {
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
        }

        // Espera el tiempo de la animación antes de cambiar de escena
        if (transitionAnimator != null)
        {
            yield return new WaitForSeconds(transitionAnimator.GetCurrentAnimatorStateInfo(0).length);
        }

        // Cargar la nueva escena
        SceneManager.LoadScene(sceneName);
    }

    // Reinicia la elección del rival de manera aleatoria
    void ResetRival()
    {
        int num = rival;
        while (rival == num)
        {
            rival = Random.Range(1, 4); // Genera un número entre 1 y 3
        }
    }
}
