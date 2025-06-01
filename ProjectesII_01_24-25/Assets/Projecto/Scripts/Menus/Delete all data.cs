using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Deletealldata : MonoBehaviour
{
    public int MainMenuScene = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("finished", 1);
        PlayerPrefs.SetInt("LastScene", 0);
        PlayerPrefs.Save();
        Debug.Log("All prefabs has been eliminated.");
        SceneManager.LoadScene(MainMenuScene);
    }
}
