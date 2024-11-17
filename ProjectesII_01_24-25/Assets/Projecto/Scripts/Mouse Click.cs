using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    public bool hasActivated = false;
    private void OnMouseDown()
    {
        hasActivated = true;
    }

    private void OnMouseUp()
    {
        hasActivated = false;
    }

}
