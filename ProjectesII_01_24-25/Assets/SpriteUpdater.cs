using UnityEngine;
using UnityEngine.UI;

public class SpriteUpdater : MonoBehaviour
{
    public RockPaperScissors gameLogic; // Referencia al script principal

    public Image playerImage; // Imagen para mostrar la elección del jugador
    public Image rivalImage; // Imagen para mostrar la elección del rival
    public Image puntuacionRivalImage; // Imagen para mostrar la puntuación del rival
    public Image puntuacionPlayerImage; // Imagen para mostrar la puntuación del jugador

    // Sprites específicos para el jugador
    public Sprite playerPiedraSprite;
    public Sprite playerPapelSprite;
    public Sprite playerTijeraSprite;

    // Sprites específicos para el rival
    public Sprite rivalPiedraSprite;
    public Sprite rivalPapelSprite;
    public Sprite rivalTijeraSprite;

    public Sprite[] scoreSprites; // Array de sprites para las puntuaciones (0, 1, 2, 3)

    public Material spriteMaterial; // Material con el shader que se aplicará a los sprites

    void Start()
    {
        // Asigna el material al inicio del juego
        AssignMaterialToImages();
    }

    void Update()
    {
        if (gameLogic != null)
        {
            // Actualizar la elección del jugador
            if (playerImage != null)
                playerImage.sprite = GetPlayerChoiceSprite(gameLogic.player);

            // Actualizar la elección del rival
            if (rivalImage != null)
                rivalImage.sprite = GetRivalChoiceSprite(gameLogic.rival);

            // Actualizar la puntuación del rival
            if (puntuacionRivalImage != null)
                puntuacionRivalImage.sprite = scoreSprites[gameLogic.puntuacionRival];

            // Actualizar la puntuación del jugador
            if (puntuacionPlayerImage != null)
                puntuacionPlayerImage.sprite = scoreSprites[gameLogic.puntuacionPlayer];
        }
    }

    // Asigna el material a las imágenes
    void AssignMaterialToImages()
    {
        if (spriteMaterial != null)
        {
            if (rivalImage != null) rivalImage.material = spriteMaterial;
            if (puntuacionRivalImage != null) puntuacionRivalImage.material = spriteMaterial;
            if (puntuacionPlayerImage != null) puntuacionPlayerImage.material = spriteMaterial;
        }
    }

    // Retorna el sprite correspondiente a la elección del jugador
    Sprite GetPlayerChoiceSprite(int choice)
    {
        switch (choice)
        {
            case 1: return playerPiedraSprite;
            case 2: return playerPapelSprite;
            case 3: return playerTijeraSprite;
            default: return null;
        }
    }

    // Retorna el sprite correspondiente a la elección del rival
    Sprite GetRivalChoiceSprite(int choice)
    {
        switch (choice)
        {
            case 1: return rivalPiedraSprite;
            case 2: return rivalPapelSprite;
            case 3: return rivalTijeraSprite;
            default: return null;
        }
    }
}