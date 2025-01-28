using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MinigameSelector : MonoBehaviour
{
    // String público para definir el nombre de la escena desde el editor
    public string sceneName;

    // Referencia al botón
    public Button button;

    // Referencia al menú de pausa
    public GameObject pauseMenu;

    private void Start()
    {
        // Asegúrate de que el botón tenga asignado el evento
        if (button != null)
        {
            button.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogWarning("No se asignó un botón en el inspector.");
        }
    }

    // Método que cambia la escena
    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            // Reanudar el tiempo del juego
            Time.timeScale = 1f;

            // Desactivar el menú de pausa si está activo
            if (pauseMenu != null && pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
            }

            // Cambiar a la escena especificada
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("El nombre de la escena no está configurado.");
        }
    }
}
