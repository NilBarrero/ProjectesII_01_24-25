using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectPrefab : MonoBehaviour
{
    // Nombre del prefab a detectar
    public string prefabName;
    public string prefabName2;
    public static bool Mom = false;
    public static bool Baby = false;


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto detectado tiene el mismo nombre que el prefab esperado
        if (collision.gameObject.name == prefabName)
        {
            if (prefabName == "Mom" && Mom == false)
            {
                Mom = true;
            }
            
            if (prefabName == "Baby" && Baby == false)
            {
                Baby = true;
            }
        }
    }
}
