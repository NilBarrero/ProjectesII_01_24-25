using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject[] objetosConLogica;  // List of objects you want to deactivate/reactivate
    private CanvasGroup canvasGroup;
    private bool menuActivo = false;
    public static bool storySelectorActive = false;

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

        // Deactivate objects with logic
        foreach (var obj in objetosConLogica)
        {
            if (obj != null)
            {
                Debug.Log("Desactivando: " + obj.name);
                obj.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Se encontró un objeto nulo en objetosConLogica.");
            }
        }

        // Activate interaction in the menu
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void StartFirstJob()
    {
        SceneManager.LoadScene("Transition Beginning");
    }

    public void StartTutorialJob()
    {
        SceneManager.LoadScene("Intro");
    }

    public void Reanudar()
    {
        StartCoroutine(ReanudarJuego());
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        storySelectorActive = true;
        SceneManager.LoadScene("Menu Principal");
    }

    private IEnumerator ReanudarJuego()
    {
        // Wait until the mouse button is released
        while (Input.GetMouseButton(0))
        {
            yield return null;
        }

        // Resume the game
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
        menuActivo = false;

        // Deactivate menu interaction
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        // Wait 200 milliseconds before reactivating objects with logic
        yield return new WaitForSecondsRealtime(0.2f);

        foreach (var obj in objetosConLogica)
        {
            if (obj != null)
            {
                Debug.Log("Reactivando: " + obj.name);
                obj.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Se encontró un objeto nulo en objetosConLogica al reactivar.");
            }
        }

        // Additional check after one second
        StartCoroutine(ForzarActivacion());
    }

    private IEnumerator ForzarActivacion()
    {
        yield return new WaitForSecondsRealtime(1f);
        foreach (var obj in objetosConLogica)
        {
            if (obj != null && !obj.activeSelf)
            {
                Debug.Log("Forzando activación de: " + obj.name);
                obj.SetActive(true);
            }
        }
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Salir_Tutorial()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuTutorial");
    }

    public void Salir_First()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuFirstJob");
    }
}
