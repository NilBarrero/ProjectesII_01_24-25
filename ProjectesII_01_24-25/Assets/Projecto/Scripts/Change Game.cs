//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGame : MonoBehaviour
{
    public float delay = 1f; // Tiempo de espera antes de cambiar la escena.
    public string[] Ram1;
    public string[] Ram2;
    public string[] Ram2_1;
    public string[] Ram2_2;
    public string[] Ram3;

    public static int index1 = 0;// Lista de nombres de escenas en la carpeta.
    public static int index2 = 0;
    public static int index3 = 0;
    //[SerializeField] private GameObject FasterText;

    // DetectPrefab detectPrefab;

    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (index1 == 0 && index2 == 0 && index3 == 0)
            {
                // si la madre es atropellada
                string sceneToLoad = Ram1[index1];
                SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada.
                index1++;
            }

            if (index2 == 1)//dinero
            {
                // si la madre es atropellada
                string sceneToLoad = Ram2_1[index2];
                SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada.
                index2++;
            }

            if (index2 == 2)//suicida
            {
                // si la madre es atropellada
                string sceneToLoad = Ram2_1[index2];
                SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada.
                index2++;
            }

        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            if (index1 == 0 && index2 == 0 && index3 == 0)//rapero
            {
                // si la madre es atropellada
                string sceneToLoad = Ram2[index2];
                SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada.
                index2++;
            }

            if (index2 == 1)//anciana
            {
                // si la madre es atropellada
                string sceneToLoad = Ram2[index2];
                SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada.
                index2++;
            }

            if (index2 == 2) //cama
            {
                // si la madre es atropellada
                string sceneToLoad = Ram2[index2];
                SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada.
                index2++;
            }

            if(index2 == 3)
            {
                // si la madre es atropellada
                string sceneToLoad = Ram2[index2];
                SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada.
                index2++;
            }

        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            if (index1 == 0 && index2 == 0 && index3 == 0)
            {
                // si la madre es atropellada
                string sceneToLoad = Ram3[index3];
                SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada.
                index3++;
            }

            if (index2 == 2)//reanimar
            {
                // si la madre es atropellada
                string sceneToLoad = Ram2_2[index2];
                SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada.
                index2++;
            }
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
