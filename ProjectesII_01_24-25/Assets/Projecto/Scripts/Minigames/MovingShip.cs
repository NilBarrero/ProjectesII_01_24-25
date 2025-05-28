using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingShip : MonoBehaviour
{
    public GameObject targetObject;
    public float moveDistance = 1.0f; 

    private void OnMouseDown()
    {
        if (targetObject != null)
        {
            Vector3 newPosition = targetObject.transform.position + new Vector3(moveDistance, 0, 0);
            targetObject.transform.position = newPosition;
        }
        else
        {
            Debug.LogWarning("Target object is not assigned.");
        }
    }
}
