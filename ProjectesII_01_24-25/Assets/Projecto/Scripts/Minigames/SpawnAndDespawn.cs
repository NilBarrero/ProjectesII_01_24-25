using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndDespawn : MonoBehaviour
{
    public Transform[] A_B; // Positions A and B where the object can spawn
    public float spawnDelay = 0.02f; 
    private float timer = 0f; 
    private int actualPosition = 0; 
    public float newSpeed; 
    public float changeSpeed; 

    private Rigidbody2D rb; 
    private FondoMove fondoMove; 

    void Start()
    {
        if (A_B == null || A_B.Length == 0)
        {
            Debug.LogError("A_B is not assigned or is empty.");
            enabled = false; 
            return;
        }

        rb = GetComponent<Rigidbody2D>(); 
        fondoMove = FindObjectOfType<FondoMove>(); 
    }

    void Update()
    {
        timer += Time.deltaTime; 

        if (timer > spawnDelay)
        {
            int num;
            do
            {
                num = Random.Range(0, A_B.Length); 
            } while (num == actualPosition); 

            actualPosition = num; 
         
            rb.position = A_B[num].position;

            timer = 0f; 
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Object clicked");

        if (fondoMove != null)
        {
            fondoMove.AumentarVelocidadTemporal(newSpeed, changeSpeed); 
        }
        else
        {
            Debug.LogWarning("FondoMove script not found.");
        }
    }
}
