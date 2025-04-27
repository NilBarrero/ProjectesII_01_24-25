using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavingSystem : MonoBehaviour
{
    public int sceneNumber;  // Scene number
    bool visited;  // Indicator if the scene was visited
    public Image image;  // Image that shows the state of the scene
    public GameObject text;

    void Start()
    {
        // Make sure the TextMeshPro is disabled initially
        text.SetActive(false);

        if (sceneNumber == SceneManager.GetActiveScene().buildIndex || visited)
        {
            text.SetActive(true);
        }
    }

    private void OnEnable()
    {
        // Get if the scene was previously visited from PlayerPrefs
        int visitedNumber = PlayerPrefs.GetInt("Scene" + sceneNumber, 0);
        visited = visitedNumber > 0;

        // Get the index of the current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Check if this node represents the current scene
        if (sceneNumber == currentSceneIndex)
        {
            // Mark the current scene in red
            if (image != null)
            {
                image.color = Color.red;
            }
            else
            {
                Debug.LogWarning("The image is not assigned in the Inspector.");
            }
        }
        else
        {
            // Change the image color depending on whether the scene was visited or not
            if (image != null)  // Check if 'image' is not null
            {
                image.color = visited ? Color.green : Color.black;
            }
            else
            {
                Debug.LogWarning("The image is not assigned in the Inspector.");
            }
        }
    }
}
