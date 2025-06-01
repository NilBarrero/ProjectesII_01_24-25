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
    private float holdTime = 0f; 
    private float updateThreshold = 0.5f; 
    private float moveThreshold = 0.1f; 

    private Rigidbody2D rb;

    private Vector3 lastMousePosition;  
    private float speedThreshold = 0.01f; 

    private float additionalHoldTime = 0f; 
    private float additionalTimeThreshold = 1f; 

    public DetectPrefab detectPrefab;
    public bool isCollisionLocked = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("This object needs to have a Rigidbody2D to apply physics.");
        }

        lastMousePosition = Input.mousePosition;
    }

    private void Update()
    {
        if (isCollisionLocked) return;

        if (isBeingHeld)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                // If the raycast hits a collider, prevent the object from going through the collider.
                // Here you can check that the collider is not the dragged object
                if (hit.collider.CompareTag("Blocker")) 
                {
                    // Prevent the object from passing through the collider
                    return; 
                }
            }

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);

            if (!particles.isPlaying)
            {
                particles.Play();
            }

            currentMousePosition = mousePos;
            if (Vector3.Distance(currentMousePosition, startMousePosition) > moveThreshold) 
            {
                moved = true;
                holdTime = 0f; 
            }
            else
            {
                holdTime += Time.deltaTime;

                if (holdTime >= updateThreshold)
                {
                    startMousePosition = currentMousePosition;
                    holdTime = 0f; 
                }
            }

            additionalHoldTime += Time.deltaTime;
            
            if (additionalHoldTime >= additionalTimeThreshold)
            {     
                Debug.Log("Additional timer reached: " + additionalHoldTime);

                additionalHoldTime = 0f;
            }

            Vector3 mouseVelocity = (mousePos - lastMousePosition) / Time.deltaTime;

            if (mouseVelocity.magnitude <= speedThreshold)
            {
                moved = false; 
                startMousePosition = mousePos;
            }

            lastMousePosition = mousePos;
        }
        else
        {
            particles.Stop();
        }
    }

    private void OnMouseDown()
    {
        if (isCollisionLocked) return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            startMousePosition = mousePos;

            isBeingHeld = true;

            particles.Play();

            moved = false;
            holdTime = 0f;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;

        if (moved)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            Vector3 dragDirection = mousePos - startMousePosition;

            ApplyLaunchForce(dragDirection);
        }
        else
        {
            // If the mouse didn't move enough (or is stationary), the object will fall without force
            rb.velocity = Vector2.zero;  
        }

        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void ApplyLaunchForce(Vector3 dragDirection)
    {
        Vector3 launchVelocity = dragDirection.normalized * 10f; 

        rb.velocity = launchVelocity;
    }
}
