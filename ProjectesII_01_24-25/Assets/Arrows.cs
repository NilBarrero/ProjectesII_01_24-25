using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public GameObject movingObject;  // Referencia al objeto que se mueve
    public bool active;

    void OnMouseDown()
    {
        active = true;
        gameObject.SetActive(false);
    }
}
