using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingPlayerPref : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firstDedliver;
    void Start()
    {
        
        int hasFinishedTutorial = PlayerPrefs.GetInt("finished", 0);

        if (hasFinishedTutorial == 0) 
        {
            firstDedliver.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
