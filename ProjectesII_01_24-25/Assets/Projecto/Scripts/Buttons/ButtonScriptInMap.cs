using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScriptInMap : MonoBehaviour
{
    public GameObject[] gameObjectsToActivate; // Array to store the game objects to activate/deactivate

    // Function that is called when the button is clicked
    public void Activate()
    {
        Debug.Log("Activate() was called!");

        foreach (GameObject obj in gameObjectsToActivate)
        {
            if (obj != null)
            {
                Debug.Log("Activating: " + obj.name); // Check which object you are activating
                obj.SetActive(true); // Activate the game object
            }
        }
    }
}


