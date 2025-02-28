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
            Debug.LogError("No se encontr� un CanvasGroup en el men� de pausa.");
        }
    }

    public void Pausa()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
        menuActivo = true;

        // Desactivar los objetos con l�gica
        foreach (var obj in objetosConLogica)
        {
            obj.SetActive(false);
        }

        // Habilitar la interacci�n con el men�
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
        // Esperar hasta que el jugador suelte el bot�n del rat�n
        while (Input.GetMouseButton(0))
        {
            yield return null;
        }

        // Restaurar el tiempo y ocultar el men�
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
        menuActivo = false;

        // Reactivar los objetos con l�gica
        foreach (var obj in objetosConLogica)
        {
            obj.SetActive(true);
        }

        // Bloquear la interacci�n con el men�
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        // Esperar un frame extra antes de reactivar la interacci�n
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
        // Si el men� est� activo, bloqueamos la entrada al juego, pero no a la UI
        if (entradaBloqueada && !IsPointerOverUI())
        {
            Input.ResetInputAxes(); // Bloqueamos la entrada solo si el puntero no est� sobre la UI
        }
    }

    // Verificar si el puntero est� sobre un UI (como los botones del men�)
    private bool IsPointerOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}

