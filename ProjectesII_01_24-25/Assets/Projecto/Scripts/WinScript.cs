using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    // Puntuaci�n accesible globalmente

    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("WinScene");
    }
}

