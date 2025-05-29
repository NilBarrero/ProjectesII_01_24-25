using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavingSystem : MonoBehaviour
{
    public int sceneNumber;
    bool visited;
    public Image image;
    public GameObject text;

    void Start()
    {
        text.SetActive(false);

        if (sceneNumber == SceneManager.GetActiveScene().buildIndex || visited)
        {
            text.SetActive(true);
        }
    }

    private void OnEnable()
    {
        int visitedNumber = PlayerPrefs.GetInt("Scene" + sceneNumber, 0);
        visited = visitedNumber > 0;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneNumber == currentSceneIndex)
        {
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
            if (image != null) 
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
