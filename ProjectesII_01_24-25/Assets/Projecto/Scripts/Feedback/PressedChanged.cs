using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedChanged : MonoBehaviour
{
    public bool haSidoPulsado = false;

    void OnMouseDown()
    {
        haSidoPulsado = true;
    }

    void Update()
    {
        
        if (!Input.GetMouseButton(0))
        {
            haSidoPulsado = false;
        }
    }
}
