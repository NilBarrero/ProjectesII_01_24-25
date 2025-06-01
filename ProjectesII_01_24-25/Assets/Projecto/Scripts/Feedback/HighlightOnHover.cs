using System.Collections;
using UnityEngine;

public class HighlightOnHover : MonoBehaviour
{
    private Renderer objectRenderer;
    public GameObject activateDialogue;
    public GameObject dialogueinactive;
    private Color originalColor;
    public Color highlightColor = Color.yellow;
    public ParticleSystem particles;

    public Texture2D customCursor;
    public Vector2 cursorHotspot = new Vector2(16, 16);

    void Start()
    {
        if (activateDialogue != null)
        {
            activateDialogue.SetActive(false);
        }

        if (dialogueinactive != null)
        {
            dialogueinactive.SetActive(true);
        }

        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }

        if (particles != null)
        {
            particles.Stop();
        }
    }

    void OnMouseEnter()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = highlightColor;
        }

        if (customCursor != null)
        {
            UnityEngine.Cursor.SetCursor(customCursor, new Vector2(customCursor.width / 2, customCursor.height / 2), CursorMode.Auto);
        }

        if (activateDialogue != null && !activateDialogue.activeSelf)
        {
            StartCoroutine(Activate(2.5f, 0f, activateDialogue));
        }
    }

    void OnMouseExit()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = originalColor;
        }

        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private IEnumerator Activate(float timeOut, float timeIn, GameObject gameobject)
    {
        yield return new WaitForSeconds(timeIn);

        if (particles != null)
        {
            particles.Play();
        }

        if (dialogueinactive != null)
        {
            dialogueinactive.SetActive(false);
        }

        if (gameobject != null)
        {
            gameobject.SetActive(true);
        }

        yield return new WaitForSeconds(timeOut);

        if (particles != null)
        {
            particles.Stop();
        }

        if (gameobject != null)
        {
            gameobject.SetActive(false);
        }

        if (dialogueinactive != null)
        {
            dialogueinactive.SetActive(true);
        }
    }

    void OnDestroy()
    {
        if (activateDialogue != null)
        {
            activateDialogue.SetActive(false);
        }
    }
}

