using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectPrefabLose : MonoBehaviour
{
    // Nombre del prefab a detectar
    public string prefabName = "Drag";


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto detectado tiene el mismo nombre que el prefab esperado
        if (collision.gameObject.name == prefabName)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
