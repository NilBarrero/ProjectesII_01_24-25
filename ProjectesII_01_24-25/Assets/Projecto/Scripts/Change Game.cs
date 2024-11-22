using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGame : MonoBehaviour
{
    public float delay = 1f; // Tiempo de espera antes de cambiar la escena.
    public string[] GameScene;
    static int index = 0;// Lista de nombres de escenas en la carpeta.
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

        if (Transition.lifes == 0)
        {
            SceneManager.LoadScene("Menu Principal");
        }
        else
        {
            string sceneToLoad = GameScene[index];
            SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada.
            index++;

            // Reiniciar el índice si llegamos al final de la lista.
            if (index >= GameScene.Length)
            {
                Debug.Log("Se completó la lista de escenas. Reiniciando el ciclo.");
                index = 3; // Reinicia para comenzar desde la primera escena.
            }
        }
          

        /*
        else
        {
            // Elegir una escena aleatoria de la lista.
            int randomIndex = Random.Range(0, GameScene.Length);
            string sceneToLoad = GameScene[randomIndex];

            SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada.
        }
        */
    }

}
