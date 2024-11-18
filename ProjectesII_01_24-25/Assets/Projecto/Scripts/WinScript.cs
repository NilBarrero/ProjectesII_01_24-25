using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public static int puntuacion = 0; // Puntuación accesible globalmente

    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("WinScene");
        puntuacion += 100;
    }
}

