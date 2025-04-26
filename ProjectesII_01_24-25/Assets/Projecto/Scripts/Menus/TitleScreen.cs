using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject storySelector;
    [SerializeField] private GameObject options;
    [SerializeField] private Animator animator; // Animator for the transition animation
    [SerializeField] private float animationDuration = 1.0f; // Duration of the animation in seconds
    [SerializeField] private AudioSource musicSource; // AudioSource for the background music
    [SerializeField] private float fadeOutDuration = 1.0f; // Duration of the fade-out in seconds

    private void Start()
    {
        // Looks for the AudioSource on the MainCamera if it's not manually assigned
        if (musicSource == null)
        {
            Camera mainCamera = Camera.main; // Get the main camera
            if (mainCamera != null)
            {
                musicSource = mainCamera.GetComponent<AudioSource>();
            }

            if (musicSource == null)
            {
                Debug.LogWarning("No AudioSource found on the MainCamera. Fade out will not be performed.");
            }
        }

        if (animator == null)
        {
            Debug.LogError("No Animator assigned. Please assign one in the Inspector.");
        }

        if (PauseMenu.storySelectorActive)
        {
            storySelector.SetActive(true);
            menuPrincipal.SetActive(false);
            PauseMenu.storySelectorActive = false; // Reset the flag
        }
    }

    public void Play()
    {
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); // Reset cursor before changing scene
        // Activates the storySelector and deactivates the menuPrincipal
        if (storySelector != null)
        {
            storySelector.SetActive(true);
            menuPrincipal.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No storySelector assigned. Cannot activate.");
        }
        // StartCoroutine(PlayAnimationAndChangeScene("Transition Beginning"));
    }

    public void Options()
    {
        // Activates the options and deactivates the menuPrincipal
        if (options != null)
        {
            options.SetActive(true);
            menuPrincipal.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No options assigned. Cannot activate.");
        }
        // StartCoroutine(PlayAnimationAndChangeScene("Transition Beginning"));
    }

    public void Exit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }


    private IEnumerator PlayAnimationAndChangeScene(string sceneName)
    {
        // Starts the fade-out of the music
        if (musicSource != null)
        {
            StartCoroutine(FadeOutMusic());
        }

        // Activates the transition animation
        if (animator != null)
        {
            animator.SetTrigger("StartTransition");
        }
        else
        {
            Debug.LogWarning("No Animator assigned. Continuing without visual transition.");
        }

        // Waits for the animation duration before loading the scene
        yield return new WaitForSeconds(animationDuration);

        // Loads the new scene
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
        musicSource.Stop(); // Completely stops the audio
    }
}
