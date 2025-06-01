using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FondoMove : MonoBehaviour
{
    public float velocity = 1f;
    public float velAccelerate = 3f;
    public float time = 0.5f;
    private float originalVel;
    public bool fleeMinigame = false;
    public PressedChanged pressed;

    private bool isSpeedingUp = false;
    private bool hasAccelerated = false;

    void Start()
    {
        originalVel = velocity;
    }

    void Update()
    {

        Vector2 movimiento = Vector2.left * velocity * Time.deltaTime;
        transform.position = (Vector2)transform.position + movimiento;

        
        if (fleeMinigame && !isSpeedingUp)
        {
            AumentarVelocidadTemporal(velAccelerate, time);
        }

        // If the button has been pressed and hasn't accelerated yet, start acceleration
        if (pressed.haSidoPulsado && !hasAccelerated)
        {
            StartCoroutine(AumentarVelocidadCoroutine(velAccelerate, time));
            hasAccelerated = true;
        }

        if (transform.position.x <= -GetComponent<Renderer>().bounds.size.x)
        {
            transform.position += new Vector3(GetComponent<Renderer>().bounds.size.x * 2, 0, 0);
        }
    }

    // Method to temporarily increase speed
    public void AumentarVelocidadTemporal(float nuevaVelocidad, float duracion)
    {
        if (isSpeedingUp) return;

        isSpeedingUp = true;
        StartCoroutine(AumentarVelocidadCoroutine(nuevaVelocidad, duracion));
    }

    private IEnumerator AumentarVelocidadCoroutine(float nuevaVelocidad, float duracion)
    {
        velocity = nuevaVelocidad;
        yield return new WaitForSeconds(duracion);
        velocity = originalVel;
        isSpeedingUp = false;
        hasAccelerated = false;
    }
}
