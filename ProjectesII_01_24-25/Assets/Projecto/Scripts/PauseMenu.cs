using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    private CanvasGroup canvasGroup;
    private bool ignorarPrimerClic = false;

    private void Start()
    {
        canvasGroup = menuPausa.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            Debug.LogError("No se encontró un CanvasGroup en el menú de pausa.");
        }
    }

    public void Pausa()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);

        // Habilitar la interacción con el menú
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        // No ignoramos el input mientras el menú está abierto
        ignorarPrimerClic = false;
    }

    public void Reanudar()
    {
        StartCoroutine(ReanudarJuego());
    }

    private IEnumerator ReanudarJuego()
    {
        // Esperar hasta que el jugador suelte el botón del ratón
        while (Input.GetMouseButton(0))
        {
            yield return null;
        }

        // Ignorar el primer clic después de cerrar el menú
        ignorarPrimerClic = true;

        // Restaurar el tiempo y ocultar el menú
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);

        // Bloquear la interacción con el menú
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        // Esperar un frame extra antes de reactivar la interacción
        yield return new WaitForEndOfFrame();

        ignorarPrimerClic = false;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        // Si se debe ignorar el primer clic, lo bloqueamos
        if (ignorarPrimerClic && Input.GetMouseButtonDown(0))
        {
            Input.ResetInputAxes();
            ignorarPrimerClic = false; // Solo se ignora un clic
        }
    }
}




