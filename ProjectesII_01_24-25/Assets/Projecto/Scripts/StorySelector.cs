using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StorySelector : MonoBehaviour
{
    [SerializeField] private FadeInOutMusic fadeMusic; // Referencia al script FadeInOutMusic.
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject storySelector;

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


