using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finished : MonoBehaviour
{
    public bool finished;
    public bool deleteOnlyForDebug = false;
    // Start is called before the first frame update
    void Start()
    {
        
        
        PlayerPrefs.SetInt("finished", finished ? 1 : 0); // Convierte el bool a int (1 o 0)
        PlayerPrefs.Save(); // Guarda los cambios
        if (deleteOnlyForDebug)
        {
            PlayerPrefs.DeleteKey("finished");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
