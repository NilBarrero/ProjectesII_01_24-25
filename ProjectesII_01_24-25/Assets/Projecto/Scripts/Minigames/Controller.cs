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

    // Variables para animación y música
    public Animator transitionAnimator;
    public AudioSource musicSource;
    public float fadeOutDuration = 1f;

    // Referencia al AudioSource para el sonido de movimiento
    public AudioSource movementAudioSource; // Ahora es solo un AudioSource, no un AudioClip

    void Start()
    {
        if (A_B == null || A_B.Length == 0)
        {
            Debug.LogError("A_B no está asignado o está vacío.");
        }

        if (ship == null)
        {
            Debug.LogError("El ship no está asignado.");
        }

        // Aseguramos que el AudioSource de movimiento esté configurado
        if (movementAudioSource == null)
        {
            Debug.LogError("El AudioSource de movimiento no está asignado.");
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

    // Método que mueve el GameObject a una nueva posición y reproduce el sonido
    private void MoveToPosition(Vector3 targetPosition)
    {
        transform.position = targetPosition;

        // Reproduce el sonido de movimiento cada vez que el objeto se mueve
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

