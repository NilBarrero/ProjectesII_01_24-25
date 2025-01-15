using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingShip : MonoBehaviour
{
    public GameObject targetObject; // El objeto que se moverá
    public float moveDistance = 1.0f; // Distancia que se moverá a la derecha

    private void OnMouseDown()
    {
        if (targetObject != null)
        {
            // Mueve el objeto objetivo una distancia hacia la derecha
            Vector3 newPosition = targetObject.transform.position + new Vector3(moveDistance, 0, 0);
            targetObject.transform.position = newPosition;
        }
        else
        {
            Debug.LogWarning("No se ha asignado el objeto objetivo.");
        }
    }
}
