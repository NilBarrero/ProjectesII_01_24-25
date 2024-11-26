using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectPrefab2 : MonoBehaviour
{
    public string prefabName1 = "Drag2";
    public string prefabIncorrectName = "Incorrect";


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto detectado tiene el mismo nombre que el prefab esperado
        if (collision.gameObject.name == prefabName1)
        {
            Transition.puntuacion += 100;
            SceneManager.LoadScene("LoseScene");
        }
        if (collision.gameObject.name == prefabIncorrectName)
        {
            if (Transition.lifes > 0)
            {
                Transition.lifes--;
            }
            SceneManager.LoadScene("LoseScene");
        }
    }
}
