using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingShip : MonoBehaviour
{
    public GameObject targetObject; // The object that will be moved
    public float moveDistance = 1.0f; // The distance it will move to the right

    private void OnMouseDown()
    {
        if (targetObject != null)
        {
            // Move the target object a certain distance to the right
            Vector3 newPosition = targetObject.transform.position + new Vector3(moveDistance, 0, 0);
            targetObject.transform.position = newPosition;
        }
        else
        {
            Debug.LogWarning("Target object is not assigned.");
        }
    }
}
