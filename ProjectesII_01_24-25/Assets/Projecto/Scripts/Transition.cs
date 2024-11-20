using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    // Start is called before the first frame update
    public static int puntuacion = 0;
    public static int lifes = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Transition Scene");
        puntuacion += 100;
    }
}
