using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressed : MonoBehaviour
{
 
    public bool haSidoPulsado = false;
    private Controller gameManager;

    void OnEnable()
    {
        
        gameManager = FindObjectOfType<Controller>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }
    }


    void OnMouseDown()
    {
        if (!haSidoPulsado) 
        {
            haSidoPulsado = true;

            if (gameManager != null)
            {
                gameManager.ObjetoPulsado(this);
            }
        }
    }
}
