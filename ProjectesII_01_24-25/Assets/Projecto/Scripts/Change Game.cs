using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGame : MonoBehaviour
{
    public float delay = 5f; // Tiempo de espera antes de cambiar la escena.
    public string[] GameScene; // Lista de nombres de escenas en la carpeta.
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
        yield return new WaitForSeconds(delay); // Espera por "delay" segundos.

        if (Transition.lifes == 0)
        {
            SceneManager.LoadScene("Menu Principal");
        }
        else
        {
            // Elegir una escena aleatoria de la lista.
            int randomIndex = Random.Range(0, GameScene.Length);
            string sceneToLoad = GameScene[randomIndex];

            SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada.
        }
    }

}
