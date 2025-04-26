using System.Collections;
using UnityEngine;

public class HighlightOnHover : MonoBehaviour
{
    private Renderer objectRenderer;
    public GameObject activateDialogue;
    public GameObject dialogueinactive;
    private Color originalColor;
    public Color highlightColor = Color.yellow; // Change this color as needed
    public ParticleSystem particles;

    // Add a reference for the custom cursor
    public Texture2D customCursor; // The cursor you want to use
    public Vector2 cursorHotspot = new Vector2(16, 16); // Define the cursor's center

    void Start()
    {
        // Initialize objects and stop particles at the start
        if (activateDialogue != null)
        {
            activateDialogue.SetActive(false);
        }
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color; // Save the original color
        }
        if (particles != null)
        {
            particles.Stop();
        }
    }

    private void Update()
    {
        // Update the dialogue state
        if (activateDialogue.activeSelf)
        {
            dialogueinactive.SetActive(false);
        }
        else
        {
            dialogueinactive.SetActive(true);
        }
    }

    void OnMouseEnter()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = highlightColor; // Change to the highlight color
        }

        // Change the cursor when the mouse hovers over
        if (customCursor != null)
        {
            UnityEngine.Cursor.SetCursor(customCursor, new Vector2(customCursor.width / 2, customCursor.height / 2), CursorMode.Auto);
        }

        // Activate particles and dialogue if not already active
        if (!activateDialogue.activeSelf && particles != null)
        {
            StartCoroutine(Activate(2.5f, 0f, activateDialogue));
        }
    }

    void OnMouseExit()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = originalColor; // Revert to the original color
        }

        // Restore the cursor to the default value
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private IEnumerator Activate(float timeOut, float timeIn, GameObject gameobject)
    {
        // Wait for the entry time (if applicable)
        yield return new WaitForSeconds(timeIn);

        // Activate particles and dialogue
        if (particles != null)
        {
            particles.Play();
        }
        gameobject.SetActive(true);

        // Wait for the exit time
        yield return new WaitForSeconds(timeOut);

        // Stop particles and deactivate dialogue
        if (particles != null)
        {
            particles.Stop();
        }
        gameobject.SetActive(false);
    }

    // This method deactivates the dialogue when the GameObject containing this script is destroyed
    void OnDestroy()
    {
        // If the object containing this script is destroyed, deactivate the dialogue
        if (activateDialogue != null)
        {
            activateDialogue.SetActive(false);
        }
    }
}

