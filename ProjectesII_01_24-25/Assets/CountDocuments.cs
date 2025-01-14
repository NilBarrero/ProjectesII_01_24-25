using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDocuments : MonoBehaviour
{
    // Array de GameObjects que contienen el script DeactivateOnTouch
    public GameObject[] documents; // Asignar todos los documentos (1 a 19) desde el Inspector

    // Contadores de clics
    public int clickCount = 0;          // Contador para los documentos de 1 a 10
    public int documentClickCount = 0;   // Contador para los documentos de 11 en adelante
    public int maxCount = 19;            // Total de documentos para el conteo
    public string sceneGood;
    public string sceneBad;
    private int totalnum = 0;

    private void Start()
    {
        // Verifica que todos los documentos est�n asignados en el Inspector
    }

    private void Update()
    {
        for (int i = 0; i < documents.Length; i++)
        {
            DeactivateOnTouch deactivateScript = documents[i].GetComponent<DeactivateOnTouch>();

            if (deactivateScript.hasBeenActivated)
            {
                IncrementClickCount(i);
                deactivateScript.hasBeenActivated = false;
            }
        }

        // Aseg�rate de que los contadores est�n actualizados
        Debug.Log("clickCount: " + clickCount);
        Debug.Log("documentClickCount: " + documentClickCount);

        if (totalnum >= maxCount)
        {
            if (clickCount > documentClickCount)
                SceneManager.LoadScene(sceneGood);
            else if (clickCount < documentClickCount)
                SceneManager.LoadScene(sceneBad);
        }
    }

    // Incrementa el contador dependiendo del �ndice del documento
    public void IncrementClickCount(int index)
    {
        Debug.Log("�ndice del documento: " + index);  // Agregar esta l�nea para depurar

        if (index < 10)  // Documentos 1 a 10 (�ndices 0 a 9)
        {
            clickCount++;
            Debug.Log("Clics (clickCount): " + clickCount);
        }
        else  // Documentos 11 a 19 (�ndices 10 a 18)
        {
            documentClickCount++;
            Debug.Log("Clics (documentClickCount): " + documentClickCount);
        }

        totalnum++;  // Aumentamos el n�mero total de clics aqu�
    }

}
