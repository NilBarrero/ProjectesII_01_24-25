using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MinigameSelector : MonoBehaviour
{
    // String p�blico para definir el nombre de la escena desde el editor
    public string sceneName;

    // Referencia al bot�n
    public Button button;

    // Referencia al men� de pausa
    public GameObject pauseMenu;

    private void Start()
    {
        // Aseg�rate de que el bot�n tenga asignado el evento
        if (button != null)
        {
            button.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogWarning("No se asign� un bot�n en el inspector.");
        }
    }

    // M�todo que cambia la escena
    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            // Reanudar el tiempo del juego
            Time.timeScale = 1f;

            // Desactivar el men� de pausa si est� activo
            if (pauseMenu != null && pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
            }

            // Cambiar a la escena especificada
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("El nombre de la escena no est� configurado.");
        }
    }
}
