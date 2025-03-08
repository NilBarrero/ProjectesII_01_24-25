using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneVisitor : MonoBehaviour
{
    public int sceneNumber;

    private void OnEnable()
    {
        PlayerPrefs.SetInt("Scene" + sceneNumber, 1);
    }

}

