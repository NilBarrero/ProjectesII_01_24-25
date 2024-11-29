//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGame : MonoBehaviour
{
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
        switch(Input.inputString.ToLower()) // Detecta la tecla y convierte a minúscula
        {
            case "1": //no kill
                SceneManager.LoadScene("Rapero!");
                break;
            case "2":
                SceneManager.LoadScene("Help Grany");
                break;
            case "3":
                SceneManager.LoadScene("Bed");
                break;
            case "4":
                SceneManager.LoadScene("Money");
                break;
            case "5":
                SceneManager.LoadScene("Save Suicide");
                break;
            case "6":
                SceneManager.LoadScene("Reanime");
                break;
            case "q":
                SceneManager.LoadScene("Busca Asiento!");
                break;
            case "w":
                SceneManager.LoadScene("Incendio!");
                break;
            case "e":
                SceneManager.LoadScene("Recoger Niña");
                break;
            case "r":
                SceneManager.LoadScene("Atropello");
                break;
            case "t":
                SceneManager.LoadScene("Suicidio");
                break;
            case "y":
                SceneManager.LoadScene("Moises!");
                break;
            case "u":
                SceneManager.LoadScene("Glitch");
                break;
            case "i":
                SceneManager.LoadScene("Elegir Puerta!");
                break;
            case "o":
                SceneManager.LoadScene("Comida Familiar");
                break;
            case "p":
                SceneManager.LoadScene("Psicologo");
                break;
            case "a":
                SceneManager.LoadScene("Ventana");
                break;
            case "s":
                SceneManager.LoadScene("Manicomio");
                break;
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
