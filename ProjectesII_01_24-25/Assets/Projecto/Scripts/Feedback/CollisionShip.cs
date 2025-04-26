using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionShip : MonoBehaviour
{
    public DetectPrefab[] detectPrefabs; // Array of scripts that detect collisions
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
        // Loop through all detectPrefabs to check if any collision is detected
        foreach (var detectPrefab in detectPrefabs)
        {
            if (detectPrefab != null && detectPrefab.isCollisioning)
            {
                transform.localScale *= multSize;
                animator.SetTrigger(animationTriggerName);

                detectPrefab.isCollisioning = false; // Reset the collision detection
            }
        }
    }
}
