using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevate : MonoBehaviour
{
    public float elevateSpeed = 2f; // Velocidad a la que el objeto se eleva automáticamente.
    public float clickDrop = 0.5f; // Cuánto se reduce la altura con cada clic.
    public float minHeight = 0f;   // Altura mínima para evitar que baje demasiado.
    public float maxHeight = 10f;  // Altura máxima para cambiar de escena.
    public string nextSceneName;   // Nombre de la escena a cargar.

    private bool hasReachedMaxHeight = false; // Para evitar múltiples cargas de escena.

    private void Update()
    {
        if (!hasReachedMaxHeight)
        {
            // Eleva el objeto automáticamente si no ha alcanzado la altura máxima.
            transform.position += Vector3.up * elevateSpeed * Time.deltaTime;

            // Si alcanza o supera la altura máxima, cambia de escena.
            if (transform.position.y >= maxHeight)
            {
                hasReachedMaxHeight = true;
                LoadNextScene();
            }
        }
    }

    private void OnMouseDown()
    {
        if (!hasReachedMaxHeight)
        {
            // Baja el objeto cuando se hace clic, si no está por debajo de la altura mínima.
            float newY = Mathf.Max(transform.position.y - clickDrop, minHeight);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }

    private void LoadNextScene()
    {
        // Carga la escena especificada.
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("El nombre de la escena no está configurado.");
        }
    }
}
