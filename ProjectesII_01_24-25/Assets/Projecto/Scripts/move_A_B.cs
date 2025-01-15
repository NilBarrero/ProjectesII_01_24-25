using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_A_B : MonoBehaviour
{
    public float speedMov;
    public Transform[] A_B;
    public float minDistance;
    public bool teleport = false;
    private int next = 0;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Turn();
    }

    // Update is called once per frame
    void Update()
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
}
