using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneVisitor : MonoBehaviour
{
    public int sceneNumber;

    private void OnEnable()
    {
        Debug.Log("Guardando escena: " + sceneNumber);
        PlayerPrefs.SetInt("Scene" + sceneNumber, 1);
        PlayerPrefs.SetInt("LastScene", sceneNumber);
        PlayerPrefs.Save();
    }
}
