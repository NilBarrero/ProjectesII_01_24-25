using UnityEngine;
using TMPro; // Import the library for using TextMeshPro
using UnityEngine.SceneManagement;
using System.Collections;

public class TimerLevel1 : MonoBehaviour
{
    public int tiempoInicial = 30; // Initial time in seconds
    private int tiempoRestante; // Remaining time
    private float tiempoTranscurrido; // Real-time timer
    public TextMeshProUGUI textoCuentaRegresiva; // Reference to the TextMeshPro text where you will display the countdown
    public string scene; // Scene to transition to when the timer reaches 0

    // Variables for animation and music
    public Animator transitionAnimator;  // Reference to the Animator for the transition animation
    public AudioSource musicSource;      // Reference to the music source
    public float fadeOutDuration = 1f;   // Duration for fading out the music

    void Start()
    {
        tiempoRestante = tiempoInicial; // Set the remaining time to the initial value
        tiempoTranscurrido = 0f; // Initialize the timer
        ActualizarTexto(); // Update the countdown text at the start
    }

    void Update()
    {
        // Only subtract when 1 real second has passed
        if (tiempoRestante > 0)
        {
            tiempoTranscurrido += Time.deltaTime; // Increase the counter with the time from the last frame

            if (tiempoTranscurrido >= 1f) // If 1 real second has passed
            {
                tiempoRestante--; // Subtract 1 second
                tiempoTranscurrido = 0f; // Reset the timer
                ActualizarTexto(); // Update the text
            }
        }

        // Change the text color based on the remaining time
        if (tiempoRestante > 7)
        {
            textoCuentaRegresiva.color = Color.green;
        }
        else if (tiempoRestante <= 7 && tiempoRestante > 3)
        {
            textoCuentaRegresiva.color = Color.yellow;
        }
        else if (tiempoRestante <= 3)
        {
            textoCuentaRegresiva.color = Color.red;
        }

        // Start the transition when the time reaches 0
        if (tiempoRestante == 0)
        {
            StartCoroutine(TransitionToScene());
        }
    }

    private IEnumerator TransitionToScene()
    {
        // Start the transition animation
        transitionAnimator.SetTrigger("StartTransition"); // Make sure you have a trigger called "StartTransition" in your Animator

        // Fade out the music
        float startVolume = musicSource.volume;
        float timeElapsed = 0f;

        while (timeElapsed < fadeOutDuration)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0f, timeElapsed / fadeOutDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the final volume is 0
        musicSource.volume = 0f;

        // Wait for the animation time before changing the scene
        yield return new WaitForSeconds(transitionAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Load the new scene
        SceneManager.LoadScene(scene);
    }

    void ActualizarTexto()
    {
        // Update the countdown text on the UI using TextMeshPro
        textoCuentaRegresiva.text = tiempoRestante.ToString() + " s";
    }
}
