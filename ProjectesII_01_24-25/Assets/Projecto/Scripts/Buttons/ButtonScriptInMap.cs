using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScriptInMap : MonoBehaviour
{
    public GameObject[] gameObjectsToActivate; 

    public void Activate()
    {
        Debug.Log("Activate() was called!");

        foreach (GameObject obj in gameObjectsToActivate)
        {
            if (obj != null)
            {
                Debug.Log("Activating: " + obj.name); 
                obj.SetActive(true); 
            }
        }
    }
}


