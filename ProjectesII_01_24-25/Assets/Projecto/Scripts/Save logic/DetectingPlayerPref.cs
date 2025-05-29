using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingPlayerPref : MonoBehaviour
{
    public GameObject firstDedliver;
    void Start()
    {
        
        int hasFinishedTutorial = PlayerPrefs.GetInt("finished", 0);

        if (hasFinishedTutorial == 0) 
        {
            firstDedliver.SetActive(true);
        }
    }

    void Update()
    {
        
    }
}
