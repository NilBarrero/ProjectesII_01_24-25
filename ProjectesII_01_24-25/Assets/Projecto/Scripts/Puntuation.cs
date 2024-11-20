using System.Collections;
using System.Collections.Generic;
using TMPro; // Importa el paquete TextMeshPro
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Referencia al componente TextMeshPro

    void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("TextMeshPro no está asignado. Arrastra el TextMeshProUGUI al campo en el Inspector.");
            return;
        }

        // Mostrar la puntuación inicial
        UpdateScoreText();
    }

    void Update()
    {
        // Actualizar el texto si cambia la puntuación
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Puntuation: " + Transition.puntuacion.ToString();
    }
}

