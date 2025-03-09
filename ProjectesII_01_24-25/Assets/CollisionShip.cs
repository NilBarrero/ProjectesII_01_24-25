using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionShip : MonoBehaviour
{
    public DetectPrefab detectPrefab; // Referencia al script que detecta colisiones
    public DetectPrefab detectPrefab1;
    public DetectPrefab detectPrefab2; 
    public DetectPrefab detectPrefab3; 
    public DetectPrefab detectPrefab4; 
    public DetectPrefab detectPrefab5; 
    public DetectPrefab detectPrefab6; 
    public DetectPrefab detectPrefab7; 
    public DetectPrefab detectPrefab8; 
    public float multSize = 3f;
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
        if (detectPrefab != null && detectPrefab.isCollisioning)
        {
            transform.localScale *= multSize;
            animator.SetTrigger(animationTriggerName);

            detectPrefab.isCollisioning = false; // Reiniciar la detección
        }
        if (detectPrefab1 != null && detectPrefab1.isCollisioning)
        {
            transform.localScale *= multSize;
            animator.SetTrigger(animationTriggerName);

            detectPrefab1.isCollisioning = false; // Reiniciar la detección
        }
        if (detectPrefab2 != null && detectPrefab2.isCollisioning)
        {
            transform.localScale *= multSize;
            animator.SetTrigger(animationTriggerName);

            detectPrefab2.isCollisioning = false; // Reiniciar la detección
        }
        if (detectPrefab3 != null && detectPrefab3.isCollisioning)
        {
            transform.localScale *= multSize;
            animator.SetTrigger(animationTriggerName);

            detectPrefab3.isCollisioning = false; // Reiniciar la detección
        }
        if (detectPrefab4 != null && detectPrefab4.isCollisioning)
        {
            transform.localScale *= multSize;
            animator.SetTrigger(animationTriggerName);

            detectPrefab4.isCollisioning = false; // Reiniciar la detección
        }
        if (detectPrefab5 != null && detectPrefab5.isCollisioning)
        {
            transform.localScale *= multSize;
            animator.SetTrigger(animationTriggerName);

            detectPrefab5.isCollisioning = false; // Reiniciar la detección
        }
        if (detectPrefab6 != null && detectPrefab6.isCollisioning)
        {
            transform.localScale *= multSize;
            animator.SetTrigger(animationTriggerName);

            detectPrefab6.isCollisioning = false; // Reiniciar la detección
        }
        if (detectPrefab7 != null && detectPrefab7.isCollisioning)
        {
            transform.localScale *= multSize;
            animator.SetTrigger(animationTriggerName);

            detectPrefab7.isCollisioning = false; // Reiniciar la detección
        }
        if (detectPrefab8 != null && detectPrefab8.isCollisioning)
        {
            transform.localScale *= multSize;
            animator.SetTrigger(animationTriggerName);

            detectPrefab8.isCollisioning = false; // Reiniciar la detección
        }
    }
}