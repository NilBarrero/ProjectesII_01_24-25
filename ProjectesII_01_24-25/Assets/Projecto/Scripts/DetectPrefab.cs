using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectPrefab : MonoBehaviour
{
    // Nombre del prefab a detectar
    public string prefabName = "Drag";
    public string prefabIncorrectName = "Incorrect";
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto detectado tiene el mismo nombre que el prefab esperado
        if (collision.gameObject.name == prefabName)
        {
            Transition.puntuacion += 100;
            SceneManager.LoadScene("Transition Scene");
        }
        if (collision.gameObject.name == prefabIncorrectName)
        {
            if (Transition.lifes > 0)
            {
                Transition.lifes--;
            }
            SceneManager.LoadScene("Transition Scene");
        }
    }
}
