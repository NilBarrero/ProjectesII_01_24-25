using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class Options : MonoBehaviour
{
    [SerializeField] private FadeInOutMusic fadeMusic; // Referencia al script FadeInOutMusic.
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject options;
    [SerializeField] private AudioMixer audioMixer;



    public void Exit()
    {
        if (menuPrincipal != null)
        {
            menuPrincipal.SetActive(true);
            options.SetActive(false);
        }
    }

    public void FullScren(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void Sound(float sound)
    {
        audioMixer.SetFloat("Sound", sound);
    }
    

}
