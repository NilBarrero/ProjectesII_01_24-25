using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndDespawn : MonoBehaviour
{
    public Transform[] A_B; // Positions A and B where the object can spawn
    public float spawnDelay = 0.02f; // Delay between spawns
    private float timer = 0f; // Timer to control spawn time
    private int actualPosition = 0; // Stores the last spawned position
    public float newSpeed; // New speed for the background
    public float changeSpeed; // Duration for the speed change

    private Rigidbody2D rb; // Rigidbody2D component of the object
    private FondoMove fondoMove; // Reference to the FondoMove script

    void Start()
    {
        if (A_B == null || A_B.Length == 0)
        {
            Debug.LogError("A_B is not assigned or is empty.");
            enabled = false; // Disables the script if A_B is not set properly
            return;
        }

        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component of the object
        fondoMove = FindObjectOfType<FondoMove>(); // Automatically finds the FondoMove script
    }

    void Update()
    {
        timer += Time.deltaTime; // Increment timer with elapsed time

        if (timer > spawnDelay)
        {
            // Generate a new random position different from the current one
            int num;
            do
            {
                num = Random.Range(0, A_B.Length); // Generate a random number between 0 and the length of A_B
            } while (num == actualPosition); // Ensure the new position is different from the previous one

            actualPosition = num; // Update the current position

            // Move the object to the new position using Rigidbody2D
            rb.position = A_B[num].position;

            timer = 0f; // Reset the timer
        }
    }

    // Detect when the object is clicked
    private void OnMouseDown()
    {
        Debug.Log("Object clicked");

        if (fondoMove != null)
        {
            // Temporarily increase the background speed
            fondoMove.AumentarVelocidadTemporal(newSpeed, changeSpeed); // Change to speed 5 for 1 second
        }
        else
        {
            Debug.LogWarning("FondoMove script not found.");
        }
    }
}
