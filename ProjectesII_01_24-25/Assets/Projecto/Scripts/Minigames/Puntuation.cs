using System.Collections;
using System.Collections.Generic;
using TMPro; // Imports the TextMeshPro package
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro component

    void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("TextMeshPro is not assigned. Please drag the TextMeshProUGUI component to the field in the Inspector.");
            return;
        }

        // Display the initial score
        UpdateScoreText();
    }

    void Update()
    {
        // Update the text if the score changes
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        // scoreText.text = "Score: " + Transition.score.ToString();
    }
}
