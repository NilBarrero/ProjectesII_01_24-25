using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingArchivementsCount : MonoBehaviour
{
    public int sceneID;

    void Start()
    {
        PlayerPrefs.SetInt(sceneID.ToString(), 1);
    }

    void Update()
    {
        
    }
}
