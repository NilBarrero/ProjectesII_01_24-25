using UnityEngine;
using UnityEngine.UI;

public class SpriteUpdater : MonoBehaviour
{
    public RockPaperScissors gameLogic; // Referencia al script principal

    public Image playerImage; // Imagen para mostrar la elecci�n del jugador
    public Image rivalImage; // Imagen para mostrar la elecci�n del rival
    public Image puntuacionRivalImage; // Imagen para mostrar la puntuaci�n del rival
    public Image puntuacionPlayerImage; // Imagen para mostrar la puntuaci�n del jugador

    public Sprite piedraSprite; // Sprite para "Piedra"
    public Sprite papelSprite; // Sprite para "Papel"
    public Sprite tijeraSprite; // Sprite para "Tijera"

    public Sprite[] scoreSprites; // Array de sprites para las puntuaciones (0, 1, 2, 3)

    void Update()
    {
        if (gameLogic != null)
        {
            // Actualizar la elecci�n del jugador
            if (playerImage != null)
                playerImage.sprite = GetChoiceSprite(gameLogic.player);

            // Actualizar la elecci�n del rival
            if (rivalImage != null)
                rivalImage.sprite = GetChoiceSprite(gameLogic.rival);

            // Actualizar la puntuaci�n del rival
            if (puntuacionRivalImage != null)
                puntuacionRivalImage.sprite = scoreSprites[gameLogic.puntuacionRival];

            // Actualizar la puntuaci�n del jugador
            if (puntuacionPlayerImage != null)
                puntuacionPlayerImage.sprite = scoreSprites[gameLogic.puntuacionPlayer];
        }
    }

    // Retorna el sprite correspondiente a la elecci�n
    Sprite GetChoiceSprite(int choice)
    {
        switch (choice)
        {
            case 1: return piedraSprite;
            case 2: return papelSprite;
            case 3: return tijeraSprite;
            default: return null;
        }
    }
}
