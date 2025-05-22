using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnTouch : MonoBehaviour
{
    public GameObject document;
    public bool hasBeenActivated = false;
    public Vector3 teleport;

    private Collider objectCollider; // To hold the collider reference


    void Start()
    {
        // Get the collider reference to disable it after activation
        objectCollider = GetComponent<Collider>();
    }

    private void OnMouseDown()
    {
        
        if (hasBeenActivated) return;

        
        hasBeenActivated = true;
        document.transform.position = teleport;
        Debug.Log("hasBeenActivated = true");

        // Disable the collider to prevent more clicks
        if (objectCollider != null)
        {
            objectCollider.enabled = false;
        }
    }
}


