using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySelector : MonoBehaviour
{
    public void FirstJob()
    {
        SceneManager.LoadScene("Transition Beginning");
    }

    public void SecondJob() 
    {
        SceneManager.LoadScene("Intro cat");
    }

    public void ThirdJob()
    {
        // Tercera entrega
    }

    public void ForthJob()
    {
        // Cuarta entrega
    }
}
