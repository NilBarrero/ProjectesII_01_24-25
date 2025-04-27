using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedChanged : MonoBehaviour
{
    // This boolean will indicate if the object has been clicked
    public bool haSidoPulsado = false;

    // This method is called when the object is clicked
    void OnMouseDown()
    {
        // Set that it has been clicked
        haSidoPulsado = true;

        // Notify the GameManager (Controller) that the object has been clicked (optional - currently no code here)
    }

    // This method is called every frame
    void Update()
    {
        // If there is no click, ensure haSidoPulsado is false
        if (!Input.GetMouseButton(0)) // If the left mouse button is not being held
        {
            haSidoPulsado = false;
        }
    }
}
