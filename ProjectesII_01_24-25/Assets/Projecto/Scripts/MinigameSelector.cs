using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameSelector : MonoBehaviour
{
    private string scene;
    public void Minigame1()
    {
        SceneManager.LoadScene(scene);
    }
}
