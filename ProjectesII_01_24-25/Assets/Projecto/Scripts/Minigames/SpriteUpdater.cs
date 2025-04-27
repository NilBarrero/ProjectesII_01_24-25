using UnityEngine;
using UnityEngine.UI;

public class SpriteUpdater : MonoBehaviour
{
    public RockPaperScissors gameLogic; // Reference to the main game logic script

    public Image playerImage; // Image to display the player's choice
    public Image rivalImage; // Image to display the rival's choice
    public Image puntuacionRivalImage; // Image to display the rival's score
    public Image puntuacionPlayerImage; // Image to display the player's score

    // Specific sprites for the player
    public Sprite playerPiedraSprite; // Sprite for rock
    public Sprite playerPapelSprite;  // Sprite for paper
    public Sprite playerTijeraSprite; // Sprite for scissors

    // Specific sprites for the rival
    public Sprite rivalPiedraSprite;  // Sprite for rival's rock
    public Sprite rivalPapelSprite;   // Sprite for rival's paper
    public Sprite rivalTijeraSprite;  // Sprite for rival's scissors

    public Sprite[] scoreSprites; // Array of sprites for the scores (0, 1, 2, 3)

    public Material spriteMaterial; // Material with the shader that will be applied to the sprites

    void Start()
    {
        // Assign the material to the images at the start of the game
        AssignMaterialToImages();
    }

    void Update()
    {
        if (gameLogic != null)
        {
            // Update the player's choice image
            if (playerImage != null)
                playerImage.sprite = GetPlayerChoiceSprite(gameLogic.player);

            // Update the rival's choice image
            if (rivalImage != null)
                rivalImage.sprite = GetRivalChoiceSprite(gameLogic.rival);

            // Update the rival's score image
            if (puntuacionRivalImage != null)
                puntuacionRivalImage.sprite = scoreSprites[gameLogic.puntuacionRival];

            // Update the player's score image
            if (puntuacionPlayerImage != null)
                puntuacionPlayerImage.sprite = scoreSprites[gameLogic.puntuacionPlayer];
        }
    }

    // Assign the material to the images
    void AssignMaterialToImages()
    {
        if (spriteMaterial != null)
        {
            if (rivalImage != null) rivalImage.material = spriteMaterial;
            if (puntuacionRivalImage != null) puntuacionRivalImage.material = spriteMaterial;
            if (puntuacionPlayerImage != null) puntuacionPlayerImage.material = spriteMaterial;
        }
    }

    // Returns the sprite corresponding to the player's choice
    Sprite GetPlayerChoiceSprite(int choice)
    {
        switch (choice)
        {
            case 1: return playerPiedraSprite;  // Rock
            case 2: return playerPapelSprite;   // Paper
            case 3: return playerTijeraSprite; // Scissors
            default: return null;
        }
    }

    // Returns the sprite corresponding to the rival's choice
    Sprite GetRivalChoiceSprite(int choice)
    {
        switch (choice)
        {
            case 1: return rivalPiedraSprite;  // Rival's rock
            case 2: return rivalPapelSprite;   // Rival's paper
            case 3: return rivalTijeraSprite;  // Rival's scissors
            default: return null;
        }
    }
}
