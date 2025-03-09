using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionShip : MonoBehaviour
{
    public DetectPrefab detectPrefab; // Referencia al script que detecta colisiones
    public float multSize = 1.5f;
    public Animator animator;
    private string animationTriggerName = "StartAnimation";

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Verificar si detectPrefab está asignado y si isCollisioning es true
        if (detectPrefab != null && detectPrefab.isCollisioning)
        {
            // Cambiar el sprite solo si revertedCollisionPropeties es true
            if (detectPrefab.revertedCollisionPropeties)
            {
                transform.localScale *= multSize;
                animator.SetTrigger(animationTriggerName);
            }
            detectPrefab.isCollisioning = false;
        }
    }
}