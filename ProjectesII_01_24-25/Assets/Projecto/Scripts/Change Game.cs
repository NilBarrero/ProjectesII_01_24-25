//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGame : MonoBehaviour
{
    int currentScene;
    int nextScene;
    int nextScenePlus;

    //public float delay = 1f; // Tiempo de espera antes de cambiar la escena.
    //public string[] Ram1;
    //public string[] Ram2;
    //public string[] Ram2_1;
    //public string[] Ram2_2;
    //public string[] Ram3;

    //public static int index1 = 0;// Lista de nombres de escenas en la carpeta.
    //public static int index2 = 0;
    //public static int index3 = 0;
    //[SerializeField] private GameObject FasterText;

    // DetectPrefab detectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        nextScene = currentScene + 1;        
        nextScenePlus = currentScene + 2;

        /*
        if (detectPrefab == null)
        {
            detectPrefab = FindAnyObjectByType <DetectPrefab>();
        }
        */
        // StartCoroutine(ChangeScene());
    }
   
    // Update is called once per frame
    void Update()
    { 
       
        if (Input.GetKeyDown(KeyCode.A) && nextScene < SceneManager.sceneCountInBuildSettings)
        {

            SceneManager.LoadScene(nextScene);
        }
        if (Input.GetKeyDown(KeyCode.D) && nextScene < SceneManager.sceneCountInBuildSettings)
        {

            SceneManager.LoadScene(nextScenePlus);
        }
    }
    /*
    IEnumerator ChangeScene()
    {
        
        //yield return new WaitForSeconds(delay); // Espera por "delay" segundos.
        
        if (index == 0)
        {
            if (detectPrefab.mom == true && detectPrefab.baby == false) // si la madre es atropellada
            {
                string sceneToLoad = Ram1[index];
                SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada.
                index++;
            }
            else if (detectPrefab.mom == false && detectPrefab.baby == true) // si el bebe es salvado
            {
                string sceneToLoad = Ram2[index];
                SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada.
                index++;
            }
            else // si no haces nada
            {
                string sceneToLoad = Ram3[index];
                SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada.
                index++;
            }
        }
        
      
    }
        */
    
}
