using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    public ParticleSystem particles;
    private float startPosX;
    private float startPosY;
    public bool isBeingHeld = false;
    private Vector3 startMousePosition;
    private Vector3 currentMousePosition;
    private bool moved = false;
    private float holdTime = 0f; // Time the mouse has been stationary
    private float updateThreshold = 0.5f; // Time to update the mouse's initial position
    private float moveThreshold = 0.1f; // Threshold to detect movement

    private Rigidbody2D rb;

    private Vector3 lastMousePosition;  // Last mouse position
    private float speedThreshold = 0.01f; // Speed threshold to consider if the mouse has moved (adjustable)

    private float additionalHoldTime = 0f; // New additional timer
    private float additionalTimeThreshold = 1f; // Threshold for the new timer (e.g., 1 second)

    public DetectPrefab detectPrefab;
    public bool isCollisionLocked = false;

    private void Start()
    {
        // Ensure the object has a Rigidbody2D to apply physics
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("This object needs to have a Rigidbody2D to apply physics.");
        }

        // Initialize the last mouse position
        lastMousePosition = Input.mousePosition;
    }

    private void Update()
    {
        if (isCollisionLocked) return;
        // If the object is being dragged
        if (isBeingHeld)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            // Raycast from the mouse to detect if it collides with something
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                // If the raycast hits a collider, prevent the object from going through the collider.
                // Here you can check that the collider is not the dragged object
                if (hit.collider.CompareTag("Blocker")) // If the collider is the one blocking movement
                {
                    // Prevent the object from passing through the collider
                    return; // Simply exit without moving the object.
                }
            }

            // If the raycast doesn't hit anything or isn't a collider that blocks movement:
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);

            // Only start particles if they are not already active
            if (!particles.isPlaying)
            {
                particles.Play();
            }

            // Check if the mouse has moved
            currentMousePosition = mousePos;
            if (Vector3.Distance(currentMousePosition, startMousePosition) > moveThreshold) // Threshold to detect movement
            {
                moved = true;
                holdTime = 0f; // Reset the timer if it moves
            }
            else
            {
                // If the mouse isn't moving, increase the timer
                holdTime += Time.deltaTime;

                // If the mouse has been stationary for longer than the threshold, update the initial position
                if (holdTime >= updateThreshold)
                {
                    startMousePosition = currentMousePosition;
                    holdTime = 0f; // Reset the timer
                }
            }

            // Increment the new additional timer
            additionalHoldTime += Time.deltaTime;

            // If the additional timer has reached the threshold, perform some action
            if (additionalHoldTime >= additionalTimeThreshold)
            {
                // Here you can do whatever is needed with the additional timer
                Debug.Log("Additional timer reached: " + additionalHoldTime);

                // Reset the additional timer
                additionalHoldTime = 0f;
            }

            // Check the mouse speed
            Vector3 mouseVelocity = (mousePos - lastMousePosition) / Time.deltaTime;

            // If the speed is zero or below the threshold, it hasn't moved
            if (mouseVelocity.magnitude <= speedThreshold)
            {
                moved = false;  // It hasn't moved with enough speed
                startMousePosition = mousePos;
            }

            // Update the last mouse position
            lastMousePosition = mousePos;
        }
        else
        {
            // Stop the particles if not being dragged
            particles.Stop();
        }
    }

    private void OnMouseDown()
    {
        if (isCollisionLocked) return;

        // Detect if the mouse has been pressed
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            startMousePosition = mousePos;

            isBeingHeld = true;

            // Start the particles immediately when the mouse is pressed
            particles.Play();

            // Reset the "moved" state
            moved = false;
            holdTime = 0f; // Reset the timer
        }
    }

    private void OnMouseUp()
    {
        // When the mouse is released, stop the drag
        isBeingHeld = false;

        // Only apply force if the mouse moved
        if (moved)
        {
            // Calculate the direction and magnitude of the launch
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            // Calculate the direction between the start position and release position
            Vector3 dragDirection = mousePos - startMousePosition;

            // Apply the velocity to the object based on the dragged distance
            ApplyLaunchForce(dragDirection);
        }
        else
        {
            // If the mouse didn't move enough (or is stationary), the object will fall without force
            rb.velocity = Vector2.zero;  // Stop any previous velocity
        }

        // Stop the particles cleanly
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void ApplyLaunchForce(Vector3 dragDirection)
    {
        // Normalize the direction so the force magnitude doesn't depend on the direction
        Vector3 launchVelocity = dragDirection.normalized * 10f; // "10f" controls the launch force

        // Apply the velocity to the Rigidbody2D
        rb.velocity = launchVelocity;
    }
}
