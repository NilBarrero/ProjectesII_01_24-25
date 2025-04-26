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

    // Fuentes de audio para cada elecci�n del rival
    public AudioSource piedraSource;  // AudioSource para piedra
    public AudioSource papelSource;   // AudioSource para papel
    public AudioSource tijeraSource;  // AudioSource para tijera

    public AudioSource audioSource; // Fuente de audio para reproducir los sonidos

    void Start()
    {
        ResetRival();
        text1.SetActive(false);
        text2.SetActive(false);

        // Asignar el componente AudioSource si no est� ya asignado
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
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

    private IEnumerator TransitionToScene(string sceneName)
    {
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("StartTransition");
        }

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

            musicSource.volume = 0f;
        }

        if (transitionAnimator != null)
        {
            yield return new WaitForSeconds(transitionAnimator.GetCurrentAnimatorStateInfo(0).length);
        }

        SceneManager.LoadScene(sceneName);
    }

    void ResetRival()
    {
        int num = rival;
        while (rival == num)
        {
            rival = Random.Range(1, 4); // Genera un n�mero entre 1 y 3
        }

        if (rival == 1)
        {
            piedraSource.Play(); // Reproducir sonido para piedra
        }
        else if (rival == 2)
        {
            papelSource.Play(); // Reproducir sonido para papel
        }
        else if (rival == 3)
        {
            tijeraSource.Play(); // Reproducir sonido para tijera
        }
    }
}

