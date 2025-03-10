using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject storySelector;
    [SerializeField] private GameObject options;
    [SerializeField] private Animator animator; // Animator para la animaci�n de transici�n
    [SerializeField] private float animationDuration = 1.0f; // Duraci�n de la animaci�n en segundos
    [SerializeField] private AudioSource musicSource; // AudioSource para la m�sica de fondo
    [SerializeField] private float fadeOutDuration = 1.0f; // Duraci�n del fade out en segundos

    private void Start()
    {
        // Busca el AudioSource en la MainCamera si no est� asignado manualmente
        if (musicSource == null)
        {
            Camera mainCamera = Camera.main; // Obtiene la c�mara principal
            if (mainCamera != null)
            {
                musicSource = mainCamera.GetComponent<AudioSource>();
            }

            if (musicSource == null)
            {
                Debug.LogWarning("No se encontr� un AudioSource en la MainCamera. No se realizar� el fade out.");
            }
        }

        if (animator == null)
        {
            Debug.LogError("No se asign� un Animator. Por favor, asigna uno en el Inspector.");
        }
    }

    public void Play()
    {
        // Activa el storySelector y desactiva el menuPrincipal
        if (storySelector != null)
        {
            storySelector.SetActive(true);
            menuPrincipal.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No se asign� un storySelector. No se puede activar.");
        }
       // StartCoroutine(PlayAnimationAndChangeScene("Transition Beginning"));
    }

    public void Options()
    {
        // Activa el storySelector y desactiva el menuPrincipal
        if (options != null)
        {
            options.SetActive(true);
            menuPrincipal.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No se asign� un storySelector. No se puede activar.");
        }
        // StartCoroutine(PlayAnimationAndChangeScene("Transition Beginning"));
    }

    public void Exit()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }

    
    private IEnumerator PlayAnimationAndChangeScene(string sceneName)
    {
        // Comienza el fade out de la m�sica
        if (musicSource != null)
        {
            StartCoroutine(FadeOutMusic());
        }

        // Activa la animaci�n de transici�n
        if (animator != null)
        {
            animator.SetTrigger("StartTransition");
        }
        else
        {
            Debug.LogWarning("No se asign� un Animator. Continuando sin transici�n visual.");
        }

        // Espera el tiempo que dura la animaci�n antes de cargar la escena
        yield return new WaitForSeconds(animationDuration);

        // Carga la nueva escena
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator FadeOutMusic()
    {
        float startVolume = musicSource.volume;

        for (float t = 0; t < fadeOutDuration; t += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0, t / fadeOutDuration);
            yield return null;
        }

        musicSource.volume = 0;
        musicSource.Stop(); // Detiene el audio completamente
    }
    
}

