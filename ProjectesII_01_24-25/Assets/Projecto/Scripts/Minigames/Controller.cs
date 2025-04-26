using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public int contador = 0;
    public int maxCount = 5;
    public string scene;
    public GameObject ship;

    public float speedMov;
    public Transform[] A_B;
    public float minDistance;
    public bool teleport = false;

    // Variables for animation and music
    public Animator transitionAnimator;
    public AudioSource musicSource;
    public float fadeOutDuration = 1f;

    // Reference to the AudioSource for the movement sound
    public AudioSource movementAudioSource; // Now it's just an AudioSource, not an AudioClip

    void Start()
    {
        if (A_B == null || A_B.Length == 0)
        {
            Debug.LogError("A_B is not assigned or is empty.");
        }

        if (ship == null)
        {
            Debug.LogError("The ship is not assigned.");
        }

        // Make sure the movement AudioSource is set up
        if (movementAudioSource == null)
        {
            Debug.LogError("The movement AudioSource is not assigned.");
        }
    }

    public void ObjetoPulsado(Pressed botonPulsado)
    {
        if (botonPulsado.haSidoPulsado)
        {
            contador++;

            if (contador < A_B.Length)
            {
                MoveToPosition(A_B[contador].position);
            }
            else
            {
                contador = 0;
                MoveToPosition(A_B[contador].position);
            }
        }

        if (maxCount == contador)
        {
            StartCoroutine(TransitionToScene());
        }

        botonPulsado.haSidoPulsado = false;
    }

    // Method to move the GameObject to a new position and play the sound
    private void MoveToPosition(Vector3 targetPosition)
    {
        transform.position = targetPosition;

        // Play the movement sound every time the object moves
        if (movementAudioSource != null)
        {
            movementAudioSource.Play();
        }
    }

    private IEnumerator TransitionToScene()
    {
        transitionAnimator.SetTrigger("StartTransition");

        float startVolume = musicSource.volume;
        float timeElapsed = 0f;

        while (timeElapsed < fadeOutDuration)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0f, timeElapsed / fadeOutDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        musicSource.volume = 0f;

        yield return new WaitForSeconds(transitionAnimator.GetCurrentAnimatorStateInfo(0).length);

        SceneManager.LoadScene(scene);
    }
}

