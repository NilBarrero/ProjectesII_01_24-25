using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Ship : MonoBehaviour
{
    public float speedMov;
    public Transform[] A_B;
    public float minDistance;
    public bool teleport = false;
    private int next = 0;
    private SpriteRenderer spriteRenderer;
    public Arrows arrows;

    private bool isMoving = false;  // Controla si el objeto se mueve o no

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Turn();
    }

    void Update()
    {
        if (arrows.active)
            isMoving = true;

        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, A_B[next].position, speedMov * Time.deltaTime);

            if (Vector2.Distance(transform.position, A_B[next].position) < minDistance)
            {
                next += 1;
                if (next >= A_B.Length)
                {
                    if (teleport == true)
                    {
                        transform.position = A_B[0].position;
                        next = 1;
                    }
                    else
                        next = 0;
                }
                Turn();
            }
        }
    }

    void Turn()
    {
        if (transform.position.x < A_B[next].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    // Método para iniciar el movimiento
    public void StartMoving()
    {
        isMoving = true;  // Comienza el movimiento cuando es llamado
    }
}

