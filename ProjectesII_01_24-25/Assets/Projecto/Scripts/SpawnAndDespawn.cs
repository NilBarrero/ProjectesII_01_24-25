using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndDespawn : MonoBehaviour
{
    public Transform[] A_B;
    public int num = 0;
    public float spawnDelay = 0.02f;
    private float timer = 0f;
    private int actualPosition = 0;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        while (num == actualPosition)
        {
            num = Random.Range(0, 6);
        }

        if (timer > spawnDelay)
        {
            if (num < A_B.Length)
            {
                // Mover el objeto usando Rigidbody2D
                rb.position = A_B[num].position;

                // Verificar si el objeto está fuera del campo de visión de la cámara
                Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

                if (viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1)
                {
                    Debug.LogWarning("El objeto está fuera del campo de visión de la cámara. Ajustando posición.");
                    Vector3 newPos = transform.position;

                    newPos.x = Mathf.Clamp(newPos.x, Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).x,
                                            Camera.main.ViewportToWorldPoint(new Vector3(1, 0, Camera.main.nearClipPlane)).x);

                    newPos.y = Mathf.Clamp(newPos.y, Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).y,
                                            Camera.main.ViewportToWorldPoint(new Vector3(0, 1, Camera.main.nearClipPlane)).y);

                    rb.position = newPos;  // Usar Rigidbody2D para actualizar la posición
                }
            }

            // Reinicia el temporizador
            timer = 0f;

            actualPosition = num;
        }
    }
}