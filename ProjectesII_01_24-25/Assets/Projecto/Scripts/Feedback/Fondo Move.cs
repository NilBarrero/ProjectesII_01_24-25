using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMove : MonoBehaviour
{
    public float velocity = 1f; // Base velocity
    public float velAccelerate = 3f; // Acceleration speed
    public float time = 0.5f; // Acceleration time
    private float originalVel; // Original speed
    public bool fleeMinigame = false; // Whether the minigame is active
    public PressedChanged pressed;

    private bool isSpeedingUp = false; // Ensures that only one speed change occurs at a time
    private bool hasAccelerated = false; // To verify if it has already accelerated

    void Start()
    {
        originalVel = velocity; // Save the initial speed
    }

    void Update()
    {
        // Move the background to the left using the current speed
        Vector2 movimiento = Vector2.left * velocity * Time.deltaTime;
        transform.position = (Vector2)transform.position + movimiento;

        // If the minigame is active and acceleration hasn't started, accelerate
        if (fleeMinigame && !isSpeedingUp)
        {
            AumentarVelocidadTemporal(velAccelerate, time);
        }

        // If the button has been pressed and hasn't accelerated yet, start acceleration
        if (pressed.haSidoPulsado && !hasAccelerated)
        {
            StartCoroutine(AumentarVelocidadCoroutine(velAccelerate, time));
            hasAccelerated = true; // Mark that it has already accelerated
        }

        // Reset the background's position if it goes off-screen
        if (transform.position.x <= -GetComponent<Renderer>().bounds.size.x)
        {
            transform.position += new Vector3(GetComponent<Renderer>().bounds.size.x * 2, 0, 0);
        }
    }

    // Method to temporarily increase speed
    public void AumentarVelocidadTemporal(float nuevaVelocidad, float duracion)
    {
        if (isSpeedingUp) return; // Prevent changing the speed if already accelerating

        isSpeedingUp = true; // Indicate that we're accelerating
        StartCoroutine(AumentarVelocidadCoroutine(nuevaVelocidad, duracion)); // Start the coroutine to accelerate
    }

    private IEnumerator AumentarVelocidadCoroutine(float nuevaVelocidad, float duracion)
    {
        velocity = nuevaVelocidad; // Switch to the new acceleration speed
        yield return new WaitForSeconds(duracion); // Wait for the acceleration duration
        velocity = originalVel; // Restore the original speed
        isSpeedingUp = false; // Reset the flag
        hasAccelerated = false; // Allow acceleration again next time
    }
}
