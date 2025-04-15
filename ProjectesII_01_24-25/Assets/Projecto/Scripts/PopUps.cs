using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopUps : MonoBehaviour
{
    public GameObject popupPanel;  
    public string sceneName = "Mapa"; 
    public float inactivityTime = 5f;  
    public float popupInterval = 10f;  

    private float inactivityTimer = 0f;  
    private float popupTimer = 0f; 
    private bool isPopupActive = false; 
    
    private bool isPlayerInteracting = false;

    private void Update()
    {
        // Verifica si estamos en la escena correcta (el mapa)
        if (SceneManager.GetActiveScene().name == sceneName)
        {
            // Monitoreamos la inactividad del jugador (aqu� lo estamos haciendo con el movimiento del rat�n)
            MonitorPlayerInactivity();

            // Si el jugador est� inactivo por demasiado tiempo, mostramos un pop-up
            if (!isPlayerInteracting)
            {
                inactivityTimer += Time.deltaTime; // Aumenta el temporizador de inactividad

                if (inactivityTimer >= inactivityTime && !isPopupActive)
                {
                    ShowPopup();  // Muestra el pop-up
                    inactivityTimer = 0f;  // Reinicia el temporizador de inactividad
                }
            }

            // Si el pop-up est� activo, gestionamos el tiempo de espera entre pop-ups
            if (isPopupActive)
            {
                popupTimer += Time.deltaTime;

                // Despu�s de un intervalo de tiempo, oculta el pop-up y reinicia el temporizador
                if (popupTimer >= popupInterval)
                {
                    HidePopup();
                    popupTimer = 0f;
                    isPopupActive = false;  // Reajusta el estado
                }
            }
        }
    }

    // M�todo para monitorear la inactividad del jugador
    private void MonitorPlayerInactivity()
    {

        if (Input.anyKey || Input.GetMouseButtonDown(0))
        {
            isPlayerInteracting = true;
            inactivityTimer = 0f;
        }
        else
        {
            isPlayerInteracting = false;
        }
    }

    // M�todo para mostrar el pop-up
    private void ShowPopup()
    {
        popupPanel.SetActive(true);  
        isPopupActive = true;  
    }

    // M�todo para ocultar el pop-up
    private void HidePopup()
    {
        popupPanel.SetActive(false);  
    }
}