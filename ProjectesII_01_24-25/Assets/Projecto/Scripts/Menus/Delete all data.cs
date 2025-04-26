using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Deletealldata : MonoBehaviour
{
    public int MainMenuScene = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("finished", 1);
        PlayerPrefs.SetInt("LastScene", 0);
        PlayerPrefs.Save();
        Debug.Log("Todos los PlayerPrefs han sido borrados.");
        SceneManager.LoadScene(MainMenuScene);
    }
}
