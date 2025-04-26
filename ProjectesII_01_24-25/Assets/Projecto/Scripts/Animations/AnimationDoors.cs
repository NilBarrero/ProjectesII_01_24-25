using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDoors : MonoBehaviour
{
    [Header("Door Animation Prefab")]
    public GameObject doorPrefab; // Asigna aquí el prefab de las puertas

    private Animator doorAnimator;

    private void Awake()
    {
        // Instancia el prefab si es necesario
        if (doorPrefab != null && doorAnimator == null)
        {
            GameObject doorInstance = Instantiate(doorPrefab, transform.position, transform.rotation);
            doorAnimator = doorInstance.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("No se asignó un prefab o el prefab no contiene un Animator.");
        }
    }

    private void Start()
    {
        OpenDoors();
    }

    private void OnDisable()
    {
        CloseDoors();
    }

    public void OpenDoors()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open");
        }
    }

    public void CloseDoors()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Close");
        }
    }
}
