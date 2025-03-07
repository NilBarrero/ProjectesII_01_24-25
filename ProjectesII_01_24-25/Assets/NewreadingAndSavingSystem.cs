using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewreadingAndSavingSystem : MonoBehaviour
{
    public int sceneNumber;
    bool visited;
    public Image image;
    private void OnEnable()
    {
        int visitedNumber = PlayerPrefs.GetInt("Scene" + sceneNumber, 0);
        visited = visitedNumber > 0;
        image.color = visited ? Color.green : Color.black;
    }

    public void LoadScene()
    {
        if (visited)
            SceneManager.LoadScene(sceneNumber);
    }
}
