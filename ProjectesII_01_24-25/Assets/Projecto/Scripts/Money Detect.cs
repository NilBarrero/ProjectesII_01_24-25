using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyDetect : MonoBehaviour
{
    // Nombre del prefab a detectar
    public string prefabName = "Drag";
    public int counter = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto detectado tiene el mismo nombre que el prefab esperado
        if (collision.gameObject.name == prefabName)
        {
            counter++;
        }
        if (counter == 2) 
        {
            SceneManager.LoadScene("Transition Scene");
        }
    }
}