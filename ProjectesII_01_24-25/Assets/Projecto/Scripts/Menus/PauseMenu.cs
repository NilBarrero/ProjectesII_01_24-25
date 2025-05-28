using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject[] objetosConLogica;
    private CanvasGroup canvasGroup;
    private bool menuActivo = false;
    public static bool storySelectorActive = false;

    private void Start()
    {
        if (menuPausa != null)
        {

            canvasGroup = menuPausa.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                Debug.LogError("Couldn't find a CanvasGroup in the pause menu");
            }
        }
    }

    public void Pausa()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
        menuActivo = true;

        foreach (var obj in objetosConLogica)
        {
            if (obj != null)
            {
                Debug.Log("Deactivating: " + obj.name);
                obj.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Se encontró un objeto nulo en objetosConLogica. Found null object in ObjectsWithLogic");
            }
        }

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
        while (Input.GetMouseButton(0))
        {
            yield return null;
        }

        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
        menuActivo = false;

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        yield return new WaitForSecondsRealtime(0.2f);

        foreach (var obj in objetosConLogica)
        {
            if (obj != null)
            {
                Debug.Log("Reactivating: " + obj.name);
                obj.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Se encontró un objeto nulo en objetosConLogica al reactivar. Found a null object in objectsWithLogic when reactivating");
            }
        }

        StartCoroutine(ForzarActivacion());
    }

    private IEnumerator ForzarActivacion()
    {
        yield return new WaitForSecondsRealtime(1f);
        foreach (var obj in objetosConLogica)
        {
            if (obj != null && !obj.activeSelf)
            {
                Debug.Log("Forcing activation of: " + obj.name);
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
