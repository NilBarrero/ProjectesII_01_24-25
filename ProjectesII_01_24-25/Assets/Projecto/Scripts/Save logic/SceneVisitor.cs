using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneVisitor : MonoBehaviour
{
    public int sceneNumber;  // This value should be set depending on the scene you're in.

    private void OnEnable()
    {
        Debug.Log("Guardando escena: " + sceneNumber);
        PlayerPrefs.SetInt("Scene" + sceneNumber, 1);  // Save a mark for the scene
        PlayerPrefs.SetInt("LastScene", sceneNumber);  // Save the number of the last scene
        PlayerPrefs.Save();  // Save the changes immediately
    }
}
