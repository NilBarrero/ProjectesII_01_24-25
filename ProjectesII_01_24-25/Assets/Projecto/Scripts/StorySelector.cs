using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StorySelector : MonoBehaviour
{
    [SerializeField] private FadeInOutMusic fadeMusic; // Referencia al script FadeInOutMusic.
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject storySelector;
    public GameObject deliver1;
    public void Start()
    {
        int finished = PlayerPrefs.GetInt("finished", 0);
        if (finished == 1)
            deliver1.SetActive(true);
    }
    public void Exit()
    {
        if (menuPrincipal != null)
        {

            menuPrincipal.SetActive(true);
            storySelector.SetActive(false);
           

        }
    }
    public void Prolog()
    {
        fadeMusic.TriggerSceneChange("Intro");
    }
    public void FirstJob()
    {

        fadeMusic.TriggerSceneChange("Transition Beginning");
    }

    public void SecondJob() 
    {
        // Segunda entrega
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


