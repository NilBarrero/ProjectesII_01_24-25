using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject storySelector;
    
    public void Play()
    {
        //menuPrincipal.SetActive(false);
        //storySelector.SetActive(true);
        SceneManager.LoadScene("Transition Beginning");
    }
    
    
    public void Exit()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }
}