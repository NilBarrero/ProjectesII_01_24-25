using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingArchivementsCount : MonoBehaviour
{
    public int sceneID;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt(sceneID.ToString(), 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
