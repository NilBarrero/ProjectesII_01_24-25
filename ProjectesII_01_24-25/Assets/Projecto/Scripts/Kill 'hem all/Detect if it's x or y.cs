using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectifitsxory : MonoBehaviour
{
    public int numOfObjects = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si se ha detectado cualquier objeto y lo destruye
        Debug.Log("Objeto detectado: " + collision.gameObject.name);  // Esto imprime el nombre del objeto
        numOfObjects++;
        Destroy(collision.gameObject);  // Destruye el objeto que ha entrado en contacto
    }
}
