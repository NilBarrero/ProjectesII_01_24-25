using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RockPaperScissors : MonoBehaviour
{
    public int rival; // Rival's choice (1 = Rock, 2 = Paper, 3 = Scissors)
    public int player; // Player's choice (1 = Rock, 2 = Paper, 3 = Scissors)
    public int puntuacionRival; // Rival's score
    public int puntuacionPlayer; // Player's score
    public float change;
    public string scene1;
    public string scene2;
    public GameObject text1;
    public GameObject text2;
    public float time;

    private float playerTimer = 0.0f; // Timer to alternate player's choice

    // Animation and music variables
    public Animator transitionAnimator;  // Reference to the Animator for animation
    public AudioSource musicSource;      // Reference to the music source
    public float fadeOutDuration = 1f;   // Music fade-out duration

    // Audio sources for each rival's choice
    public AudioSource piedraSource;  // AudioSource for rock
    public AudioSource papelSource;   // AudioSource for paper
    public AudioSource tijeraSource;  // AudioSource for scissors

    public AudioSource audioSource; // AudioSource for playing sounds

    void Start()
    {
        ResetRival();
        text1.SetActive(false);
        text2.SetActive(false);

        // Assign AudioSource component if it's not already assigned
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Alternate the player's choice every 0.9 seconds
        playerTimer += Time.deltaTime;
        if (playerTimer >= change)
        {
            player = (player % 3) + 1; // Alternates between 1, 2, and 3
            playerTimer = 0.0f;
        }
    }

    void OnMouseDown()
    {
        // Compare the choices and update scores
        if (player == rival)
        {
            Debug.Log("Draw");
        }
        else if ((player == 1 && rival == 3) || (player == 2 && rival == 1) || (player == 3 && rival == 2))
        {
            Debug.Log("Player wins");
            puntuacionPlayer++;
            change -= 0.1f;
            text1.SetActive(true);
            StartCoroutine(Desactive(time));

        }
        else
        {
            Debug.Log("Rival wins");
            puntuacionRival++;
            change += 0.1f;
            text2.SetActive(true);
            StartCoroutine(Desactive(time));
        }

        // Reset the rival's choice
        ResetRival();

        // Check if someone has won
        if (puntuacionPlayer > 2)
        {
            Debug.Log("Player wins the game!");
            StartCoroutine(TransitionToScene(scene1));
        }
        else if (puntuacionRival > 2)
        {
            Debug.Log("Rival wins the game!");
            StartCoroutine(TransitionToScene(scene2));
        }

        IEnumerator Desactive(float time)
        {
            yield return new WaitForSeconds(time);
            text1.SetActive(false);
            text2.SetActive(false);
        }
    }

    private IEnumerator TransitionToScene(string sceneName)
    {
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("StartTransition");
        }

        if (musicSource != null)
        {
            float startVolume = musicSource.volume;
            float timeElapsed = 0f;

            while (timeElapsed < fadeOutDuration)
            {
                musicSource.volume = Mathf.Lerp(startVolume, 0f, timeElapsed / fadeOutDuration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            musicSource.volume = 0f;
        }

        if (transitionAnimator != null)
        {
            yield return new WaitForSeconds(transitionAnimator.GetCurrentAnimatorStateInfo(0).length);
        }

        SceneManager.LoadScene(sceneName);
    }

    void ResetRival()
    {
        int num = rival;
        while (rival == num)
        {
            rival = Random.Range(1, 4); // Generate a random number between 1 and 3
        }

        if (rival == 1)
        {
            piedraSource.Play(); // Play sound for rock
        }
        else if (rival == 2)
        {
            papelSource.Play(); // Play sound for paper
        }
        else if (rival == 3)
        {
            tijeraSource.Play(); // Play sound for scissors
        }
    }
}
