using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationZ; // Ángulo de rotación en Z (visible en el Inspector)
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>(); // Obtener el RectTransform de la imagen
    }

    void Update()
    {
        // Si el juego está en ejecución, actualizar la rotación en cada frame
        if (Application.isPlaying)
        {
            rectTransform.localRotation = Quaternion.Euler(0, 0, rotationZ);
        }
    }

    void OnValidate()
    {
        // Permite que la rotación cambie en tiempo real dentro del Editor
        if (rectTransform == null) rectTransform = GetComponent<RectTransform>();
        rectTransform.localRotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
