using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressed : MonoBehaviour
{
    // This boolean will indicate if the object has been clicked
    public bool haSidoPulsado = false;

    // Reference to the Controller (GameManager)
    private Controller gameManager;

    // This method is called every time the prefab is enabled
    void OnEnable()
    {
        // Find the GameManager (Controller) in the scene
        gameManager = FindObjectOfType<Controller>();

        // Check if the Controller was found
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }
    }

    // This method is called when the object is clicked
    void OnMouseDown()
    {
        if (!haSidoPulsado)  // Only process if it has not been clicked before
        {
            // Set that it has been clicked
            haSidoPulsado = true;

            // Notify the GameManager (Controller) that the object has been clicked
            if (gameManager != null)
            {
                gameManager.ObjetoPulsado(this); // Pass 'this' as a reference to Pressed
            }
        }
    }
}
