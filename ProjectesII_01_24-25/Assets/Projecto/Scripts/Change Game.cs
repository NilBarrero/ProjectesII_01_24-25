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
    //public string[] Ram2_1;
    //public string[] Ram2_2;
    public string[] Ram3;

    static int index = 0;// Lista de nombres de escenas en la carpeta.
    [SerializeField] private GameObject FasterText;

    DetectPrefab detectPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        if (detectPrefab == null)
        {
            detectPrefab = FindAnyObjectByType <DetectPrefab>();
        }
        StartCoroutine(ChangeScene());
    }
   
    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(delay); // Espera por "delay" segundos.

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
}
