using UnityEngine;

public class RockPaperScissors : MonoBehaviour
{
    public int rival; // Elecci�n del rival (1 = Piedra, 2 = Papel, 3 = Tijera)
    public int player; // Elecci�n del jugador (1 = Piedra, 2 = Papel, 3 = Tijera)
    public int puntuacionRival; // Puntuaci�n del rival
    public int puntuacionPlayer; // Puntuaci�n del jugador
    public float change;

    private float playerTimer = 0.0f; // Temporizador para alternar la elecci�n del jugador

    void Start()
    {
        ResetRival();
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
        }
        else
        {
            Debug.Log("Rival gana");
            puntuacionRival++;
        }

        // Reinicia la elecci�n del rival
        ResetRival();

        // Verifica si alguien ha ganado
        if (puntuacionPlayer >= 3)
        {
            Debug.Log("�Jugador gana la partida!");
            EndGame();
        }
        else if (puntuacionRival >= 3)
        {
            Debug.Log("�Rival gana la partida!");
            EndGame();
        }
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

    // Finaliza el juego
    void EndGame()
    {
        Debug.Log("Juego terminado");
        puntuacionPlayer = 0;
        puntuacionRival = 0;
        ResetRival();
    }
}
