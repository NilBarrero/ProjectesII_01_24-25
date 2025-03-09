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
        
        
        PlayerPrefs.SetInt("finished", 0);
        
        if (deleteOnlyForDebug)
        {
            PlayerPrefs.SetInt("finished", 1);


        }
        PlayerPrefs.Save();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
