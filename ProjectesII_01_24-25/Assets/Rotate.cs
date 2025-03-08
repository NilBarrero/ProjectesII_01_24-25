using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationZ; // �ngulo de rotaci�n en Z (visible en el Inspector)
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>(); // Obtener el RectTransform de la imagen
    }

    void Update()
    {
        // Si el juego est� en ejecuci�n, actualizar la rotaci�n en cada frame
        if (Application.isPlaying)
        {
            rectTransform.localRotation = Quaternion.Euler(0, 0, rotationZ);
        }
    }

    void OnValidate()
    {
        // Permite que la rotaci�n cambie en tiempo real dentro del Editor
        if (rectTransform == null) rectTransform = GetComponent<RectTransform>();
        rectTransform.localRotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
