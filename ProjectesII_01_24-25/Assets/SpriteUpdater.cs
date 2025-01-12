using UnityEngine;
using UnityEngine.UI;

public class SpriteUpdater : MonoBehaviour
{
    public RockPaperScissors gameLogic; // Referencia al script principal

    public Image playerImage; // Imagen para mostrar la elección del jugador
    public Image rivalImage; // Imagen para mostrar la elección del rival
    public Image puntuacionRivalImage; // Imagen para mostrar la puntuación del rival
    public Image puntuacionPlayerImage; // Imagen para mostrar la puntuación del jugador

    public Sprite piedraSprite; // Sprite para "Piedra"
    public Sprite papelSprite; // Sprite para "Papel"
    public Sprite tijeraSprite; // Sprite para "Tijera"

    public Sprite[] scoreSprites; // Array de sprites para las puntuaciones (0, 1, 2, 3)

    void Update()
    {
        if (gameLogic != null)
        {
            // Actualizar la elección del jugador
            if (playerImage != null)
                playerImage.sprite = GetChoiceSprite(gameLogic.player);

            // Actualizar la elección del rival
            if (rivalImage != null)
                rivalImage.sprite = GetChoiceSprite(gameLogic.rival);

            // Actualizar la puntuación del rival
            if (puntuacionRivalImage != null)
                puntuacionRivalImage.sprite = scoreSprites[gameLogic.puntuacionRival];

            // Actualizar la puntuación del jugador
            if (puntuacionPlayerImage != null)
                puntuacionPlayerImage.sprite = scoreSprites[gameLogic.puntuacionPlayer];
        }
    }

    // Retorna el sprite correspondiente a la elección
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
