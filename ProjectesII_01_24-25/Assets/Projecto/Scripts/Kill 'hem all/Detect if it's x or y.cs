using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Detectifitsxory : MonoBehaviour
{
    // Nombre del prefab a detectar
    public string prefabName;
    public string prefabName2;
    public string prefabName3;
    public string prefabName4;
    public GameObject prefab;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public string scene;
    public int numOfObjects = 0;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto detectado tiene el mismo nombre que el prefab esperado
        if (collision.gameObject.name == prefabName)
        {
            numOfObjects++;
            Destroy(prefab);
        }

        if (collision.gameObject.name == prefabName2)
        {
            numOfObjects++;
            Destroy(prefab2);
        }

        if (collision.gameObject.name == prefabName3)
        {
            numOfObjects++;
            Destroy(prefab3);
        }

        if (collision.gameObject.name == prefabName4)
        {
            numOfObjects++; 
            Destroy(prefab4);
        }
    }

}
