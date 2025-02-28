using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject[] objetosConLogica;  // Lista de objetos que quieres desactivar
    private CanvasGroup canvasGroup;
    private bool entradaBloqueada = false;
    private bool menuActivo = false;

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
        menuActivo = true;

        // Desactivar los objetos con lógica
        foreach (var obj in objetosConLogica)
        {
            obj.SetActive(false);
        }

        // Habilitar la interacción con el menú
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        // Bloquear la entrada para los objetos del juego
        entradaBloqueada = true;
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

        // Restaurar el tiempo y ocultar el menú
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
        menuActivo = false;

        // Reactivar los objetos con lógica
        foreach (var obj in objetosConLogica)
        {
            obj.SetActive(true);
        }

        // Bloquear la interacción con el menú
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        // Esperar un frame extra antes de reactivar la interacción
        yield return new WaitForEndOfFrame();

        // Desbloquear la entrada para el juego
        entradaBloqueada = false;
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
        // Si el menú está activo, bloqueamos la entrada al juego, pero no a la UI
        if (entradaBloqueada && !IsPointerOverUI())
        {
            Input.ResetInputAxes(); // Bloqueamos la entrada solo si el puntero no está sobre la UI
        }
    }

    // Verificar si el puntero está sobre un UI (como los botones del menú)
    private bool IsPointerOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}

