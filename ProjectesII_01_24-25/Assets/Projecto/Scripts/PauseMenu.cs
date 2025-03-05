using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject[] objetosConLogica;  // Lista de objetos que quieres desactivar/reactivar
    private CanvasGroup canvasGroup;
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

        // Activar interacción en el menú
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void Reanudar()
    {
        StartCoroutine(ReanudarJuego());
    }

    private IEnumerator ReanudarJuego()
    {
        // Esperar hasta que se suelte el botón del ratón
        while (Input.GetMouseButton(0))
        {
            yield return null;
        }

        // Reanudar el juego
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
        menuActivo = false;

        // Desactivar la interacción del menú
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        // Esperar 200 milisegundos antes de reactivar los objetos con lógica
        yield return new WaitForSecondsRealtime(0.2f);

        foreach (var obj in objetosConLogica)
        {
            obj.SetActive(true);
        }
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
}





