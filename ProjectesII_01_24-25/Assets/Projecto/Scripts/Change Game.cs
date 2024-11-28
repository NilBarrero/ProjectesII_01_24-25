using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGame : MonoBehaviour
{
    public float delay = 1f; // Tiempo de espera antes de cambiar la escena.
    public string[] Ram1;
    public string[] Ram2;
    public string[] Ram3;
    static int index = 1;// Lista de nombres de escenas en la carpeta.
    [SerializeField] private GameObject FasterText;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeScene());
    }
   
    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator ChangeScene()
    {
        if (index == 3)
        {
            FasterText.SetActive(true);
        }

        yield return new WaitForSeconds(delay); // Espera por "delay" segundos.
        /*
        if 
        {
            string sceneToLoad = Ram1[index];
            SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada.
            index++;

            /*
            // Reiniciar el índice si llegamos al final de la lista.
            if (index >= Ram1.Length)
            {
                index = 3; // Reinicia para comenzar desde la primera escena.
            }
            *//*
        }
        else if
        {
            string sceneToLoad = Ram2[index];
            SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada.
            index++;
        }
        else
        {
            string sceneToLoad = Ram2[index];
            SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada.
            index++;
        }
        */
        
    }
}
