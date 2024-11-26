using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectPrefab : MonoBehaviour
{
    // Nombre del prefab a detectar
    public string prefabName1 = "Baby";
    public string prefabIncorrectName = "Incorrect";
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto detectado tiene el mismo nombre que el prefab esperado
        if (collision.gameObject.name == prefabName1)
        {
            Transition.puntuacion += 100;
            SceneManager.LoadScene("Rapero!");
        }
        if (collision.gameObject.name == prefabIncorrectName)
        {
            if (Transition.lifes > 0)
            {
                Transition.lifes--;
            }
            SceneManager.LoadScene("Rapero!");
        }
    }
}
