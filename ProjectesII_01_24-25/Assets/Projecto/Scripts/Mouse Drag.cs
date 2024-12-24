using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    public ParticleSystem particles;
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;

    private void Update()
    {
        // Mueve el objeto solo si está siendo arrastrado
        if (isBeingHeld)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);

            // Solo iniciar las partículas si no están ya activas
            if (!particles.isPlaying)
            {
                particles.Play();
            }
        }
        else
            particles.Stop();
    }

    private void OnMouseDown()
    {
        // Detecta si el mouse ha sido presionado
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;

            // Inicia las partículas directamente al presionar el mouse
            particles.Play();
        }
    }

    private void OnMouseUp()
    {
        // Cuando el mouse se suelta, detener el arrastre y las partículas
        isBeingHeld = false;

        // Detener las partículas de forma limpia
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }
}
