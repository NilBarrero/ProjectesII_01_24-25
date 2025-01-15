using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RockPaperScissors : MonoBehaviour
{
    public int rival; // Elecci�n del rival (1 = Piedra, 2 = Papel, 3 = Tijera)
    public int player; // Elecci�n del jugador (1 = Piedra, 2 = Papel, 3 = Tijera)
    public int puntuacionRival; // Puntuaci�n del rival
    public int puntuacionPlayer; // Puntuaci�n del jugador
    public float change;
    public string scene1;
    public string scene2;
    public GameObject text1;
    public GameObject text2;
    public float time;

    private float playerTimer = 0.0f; // Temporizador para alternar la elecci�n del jugador

    // Variables para animaci�n y m�sica
    public Animator transitionAnimator;  // Referencia al Animator para la animaci�n
    public AudioSource musicSource;      // Referencia a la fuente de m�sica
    public float fadeOutDuration = 1f;   // Duraci�n del fade out de la m�sica

    void Start()
    {
        ResetRival();
        text1.SetActive(false);
        text2.SetActive(false);
    }

    void Update()
    {
        // Alterna la elecci�n del jugador cada 0.9 segundos
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

        // Reinicia la elecci�n del rival
        ResetRival();

        // Verifica si alguien ha ganado
        if (puntuacionPlayer > 2)
        {
            Debug.Log("�Jugador gana la partida!");
            StartCoroutine(TransitionToScene(scene1));
        }
        else if (puntuacionRival > 2)
        {
            Debug.Log("�Rival gana la partida!");
            StartCoroutine(TransitionToScene(scene2));
        }

        IEnumerator Desactive(float time)
        {
            yield return new WaitForSeconds(time);
            text1.SetActive(false);
            text2.SetActive(false);
        }
    }

    // Corutina para manejar la transici�n de escena
    private IEnumerator TransitionToScene(string sceneName)
    {
        // Inicia la animaci�n de transici�n
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("StartTransition"); // Aseg�rate de tener un trigger llamado "StartTransition"
        }

        // Fade out de la m�sica
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

        // Espera el tiempo de la animaci�n antes de cambiar de escena
        if (transitionAnimator != null)
        {
            yield return new WaitForSeconds(transitionAnimator.GetCurrentAnimatorStateInfo(0).length);
        }

        // Cargar la nueva escena
        SceneManager.LoadScene(sceneName);
    }

    // Reinicia la elecci�n del rival de manera aleatoria
    void ResetRival()
    {
        int num = rival;
        while (rival == num)
        {
            rival = Random.Range(1, 4); // Genera un n�mero entre 1 y 3
        }
    }
}
