using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagercounter : MonoBehaviour
{
    // Start is called before the first frame update
    // Variable para almacenar el conteo de los clics
    public int clickCount = 0;
    public int maxCount = 3;
    public string scene;
    public bool dontKillCertainNumOfEnemies = false;
    public int numOfMinNumber;

    public CuentaRegresiva timer;

   
    

    public string sceneDontKillCertainNumOfEnemies;

    //int currentCount = 0;
    private void Update()
    {
        if (dontKillCertainNumOfEnemies && clickCount >= numOfMinNumber && clickCount < maxCount && timer.tiempoRestante == 0)
        {
            SceneManager.LoadScene(sceneDontKillCertainNumOfEnemies);


        }
        else if (clickCount == maxCount)
        {
            SceneManager.LoadScene(scene);
            //Transition.puntuacion += 100;
        }

        

       
    }
    // Método para incrementar el contador
    public void IncrementClickCount()
    {
        clickCount++;
        Debug.Log("Clics: " + clickCount); // Muestra el conteo en la consola
    }
}
