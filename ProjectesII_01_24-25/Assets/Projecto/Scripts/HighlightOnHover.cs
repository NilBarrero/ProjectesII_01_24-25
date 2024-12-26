using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnHover : MonoBehaviour
{
    private Renderer objectRenderer;
    public GameObject activateDialogue;
    public bool activeDialogueActive = false;
    private ActivateanddeactivateSpeech dialogue;
    public GameObject dialogueinactive;
    private Color originalColor;
    public Color highlightColor = Color.yellow; // Cambia este color según tu necesidad
    public ParticleSystem particles;
    

    void Start()
    {
        activateDialogue.SetActive(false);
        activeDialogueActive= false;

        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color; // Guarda el color original
            particles.Stop();
        }
    }

    private void Update()
    {
        if (activeDialogueActive)
        {
            dialogueinactive.SetActive(false);
        }
        else if (!activeDialogueActive)
        {
            dialogueinactive.SetActive(true);
        }
    }
    void OnMouseEnter()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = highlightColor; // Cambia al color de resaltado
            
        }
        if (!activeDialogueActive)
        {
            StartCoroutine(Activate(2.5f, 0f, activateDialogue));
            activeDialogueActive = true;
            
        }
    }

    void OnMouseExit()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = originalColor; // Vuelve al color original

        }
    }

    private IEnumerator Activate(float timeOut, float timeIn, GameObject gameobject)
    {
        yield return new WaitForSeconds(timeIn);
        // Cambiar el color al de resaltado
        particles.Play();
        gameobject.SetActive(true);


        // Esperar el tiempo especificado
        yield return new WaitForSeconds(timeOut);

        // Volver al color original
        particles.Play();
        gameobject.SetActive(false);
        activeDialogueActive= false;
        


    }
}

