using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{

    public GameObject movingObject;  // Reference to the object
    public bool active;


    void OnMouseDown()
    {
        active = true;
        Destroy(gameObject);

    }

}
