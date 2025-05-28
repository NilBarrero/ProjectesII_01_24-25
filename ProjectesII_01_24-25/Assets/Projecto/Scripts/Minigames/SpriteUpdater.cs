using UnityEngine;
using UnityEngine.UI;

public class SpriteUpdater : MonoBehaviour
{
    public RockPaperScissors gameLogic; 

    public Image playerImage; 
    public Image rivalImage;
    public Image puntuacionRivalImage; 
    public Image puntuacionPlayerImage; 

    // Specific sprites for the player
    public Sprite playerPiedraSprite; 
    public Sprite playerPapelSprite;  
    public Sprite playerTijeraSprite; 

    // Specific sprites for the rival
    public Sprite rivalPiedraSprite;  
    public Sprite rivalPapelSprite;   
    public Sprite rivalTijeraSprite;  

    public Sprite[] scoreSprites; // Array of sprites for the scores (0, 1, 2, 3)

    public Material spriteMaterial; 

    void Start()
    {
        AssignMaterialToImages();
    }

    void Update()
    {
        if (gameLogic != null)
        {
            if (playerImage != null)
                playerImage.sprite = GetPlayerChoiceSprite(gameLogic.player);

            if (rivalImage != null)
                rivalImage.sprite = GetRivalChoiceSprite(gameLogic.rival);

            if (puntuacionRivalImage != null)
                puntuacionRivalImage.sprite = scoreSprites[gameLogic.puntuacionRival];

            if (puntuacionPlayerImage != null)
                puntuacionPlayerImage.sprite = scoreSprites[gameLogic.puntuacionPlayer];
        }
    }

    void AssignMaterialToImages()
    {
        if (spriteMaterial != null)
        {
            if (rivalImage != null) rivalImage.material = spriteMaterial;
            if (puntuacionRivalImage != null) puntuacionRivalImage.material = spriteMaterial;
            if (puntuacionPlayerImage != null) puntuacionPlayerImage.material = spriteMaterial;
        }
    }

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
