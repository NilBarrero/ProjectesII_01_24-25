using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnTouch : MonoBehaviour
{
    public GameObject document;
    public bool hasBeenActivated = false;
    public Vector3 teleport;

    private Collider objectCollider; // To hold the collider reference

    // Start is called before the first frame update
    void Start()
    {
        // Get the collider reference to disable it after activation
        objectCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        // You can perform other updates if needed, like checking if 'hasBeenActivated' is true
    }

    private void OnMouseDown()
    {
        // Prevent further activation if already done
        if (hasBeenActivated) return;

        // Set the flag to true and teleport the document
        hasBeenActivated = true;
        document.transform.position = teleport;
        Debug.Log("hasBeenActivated = true");

        // Optionally disable the collider to prevent more clicks
        if (objectCollider != null)
        {
            objectCollider.enabled = false;
        }
    }
}


