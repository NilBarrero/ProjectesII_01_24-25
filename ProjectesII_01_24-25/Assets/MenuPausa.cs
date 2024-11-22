using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPause;
    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject coll1;
    [SerializeField] private GameObject coll2;
    [SerializeField] private GameObject coll3;
    [SerializeField] private GameObject coll4;
    public void Pause()
    {
        Time.timeScale = 0f;
        botonPause.SetActive(false);
        menuPause.SetActive(true);
        coll1.SetActive(false);
        coll2.SetActive(false);
        coll3.SetActive(false);
        coll4.SetActive(false);
    }

    public void Reanude()
    {
        Time.timeScale = 1f;
        botonPause.SetActive(true);
        menuPause.SetActive(false);
        coll1.SetActive(true);
        coll2.SetActive(true);
        coll3.SetActive(true);
        coll4.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu Principal");
    }

}