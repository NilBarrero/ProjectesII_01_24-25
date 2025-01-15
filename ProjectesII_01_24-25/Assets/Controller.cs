using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.AxisState;

public class Controller : MonoBehaviour
{
    // Contador que se incrementa cuando un objeto es pulsado
    public int contador = 0;
    public int maxCount = 5;
    public string scene;
    public GameObject ship;

    public float speedMov;
    public Transform[] A_B;
    public float minDistance;
    public bool teleport = false;

    // Variables para animaci�n y m�sica
    public Animator transitionAnimator;  // Referencia al Animator para la animaci�n
    public AudioSource musicSource;      // Referencia a la fuente de m�sica
    public float fadeOutDuration = 1f;   // Duraci�n del fade out de la m�sica

    void Start()
    {
        if (A_B == null || A_B.Length == 0)
        {
            Debug.LogError("A_B no est� asignado o est� vac�o.");
        }

        if (ship == null)
        {
            Debug.LogError("El ship no est� asignado.");
        }
    }

    // Este m�todo es llamado cuando un GameObject ha sido pulsado
    public void ObjetoPulsado(Pressed botonPulsado)
    {
        if (botonPulsado.haSidoPulsado)
        {
            contador++; // Incrementamos el contador

            // Aseguramos que el contador no se salga del rango del array A_B
            if (contador < A_B.Length)
            {
                transform.position = A_B[contador].position;
            }
            else
            {
                // Si contador excede el tama�o del array, lo reseteamos o lo ajustamos a un valor v�lido.
                contador = 0;
                transform.position = A_B[contador].position;
            }
        }

        if (maxCount == contador)
        {
            StartCoroutine(TransitionToScene());
        }

        botonPulsado.haSidoPulsado = false; // Reiniciamos el estado de pulsado
    }

    private IEnumerator TransitionToScene()
    {
        // Inicia la animaci�n de transici�n
        transitionAnimator.SetTrigger("StartTransition"); // Aseg�rate de tener un trigger llamado "StartTransition" en tu Animator

        // Fade out de la m�sica
        float startVolume = musicSource.volume;
        float timeElapsed = 0f;

        while (timeElapsed < fadeOutDuration)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0f, timeElapsed / fadeOutDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Asegura que el volumen final sea 0
        musicSource.volume = 0f;

        // Espera el tiempo de la animaci�n antes de cambiar de escena
        yield return new WaitForSeconds(transitionAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Cargar la nueva escena
        SceneManager.LoadScene(scene);
    }
}
