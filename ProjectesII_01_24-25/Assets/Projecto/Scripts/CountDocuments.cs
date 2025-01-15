using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDocuments : MonoBehaviour
{
    // Array de GameObjects que contienen el script DeactivateOnTouch
    public GameObject[] documents; // Asignar todos los documentos (1 a 19) desde el Inspector

    // Contadores de clics
    public int clickCount = 0;          // Contador para los documentos de 1 a 10
    public int documentClickCount = 0;   // Contador para los documentos de 11 en adelante
    public int maxCount = 19;            // Total de documentos para el conteo
    public string sceneGood;
    public string sceneBad;
    private int totalnum = 0;

    // Variables para la animación y música
    public Animator transitionAnimator;  // Referencia al Animator para la animación
    public AudioSource musicSource;      // Referencia al AudioSource para la música
    public float fadeOutDuration = 1f;   // Duración del fade out de la música

    // Variable para el audio del clic
    public AudioClip clickSound;         // Asigna el sonido en el Inspector

    private void Start()
    {
        // Verifica que todos los documentos están asignados en el Inspector
        if (documents == null || documents.Length == 0)
        {
            Debug.LogError("El array de documentos no está asignado o está vacío.");
        }
    }

    private void Update()
    {
        for (int i = 0; i < documents.Length; i++)
        {
            DeactivateOnTouch deactivateScript = documents[i].GetComponent<DeactivateOnTouch>();

            if (deactivateScript.hasBeenActivated)
            {
                IncrementClickCount(i);
                deactivateScript.hasBeenActivated = false;

                // Reproduce el sonido al hacer clic
                if (clickSound != null && musicSource != null)
                {
                    musicSource.PlayOneShot(clickSound);
                }
            }
        }

        // Asegúrate de que los contadores estén actualizados
        Debug.Log("clickCount: " + clickCount);
        Debug.Log("documentClickCount: " + documentClickCount);

        if (totalnum >= maxCount)
        {
            if (clickCount > documentClickCount)
            {
                StartCoroutine(TransitionToScene(sceneGood));
            }
            else if (clickCount < documentClickCount)
            {
                StartCoroutine(TransitionToScene(sceneBad));
            }
        }
    }

    // Incrementa el contador dependiendo del índice del documento
    public void IncrementClickCount(int index)
    {
        Debug.Log("Índice del documento: " + index);  // Agregar esta línea para depurar

        if (index < 13)  // Documentos 1 a 10 (índices 0 a 12)
        {
            clickCount++;
            Debug.Log("Clics (clickCount): " + clickCount);
        }
        else  // Documentos 11 a 19 (índices 13 a 18)
        {
            documentClickCount++;
            Debug.Log("Clics (documentClickCount): " + documentClickCount);
        }

        totalnum++;  // Aumentamos el número total de clics aquí
    }

    // Corutina para manejar la transición de escena
    private IEnumerator TransitionToScene(string sceneName)
    {
        // Inicia la animación de transición
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("StartTransition"); // Asegúrate de que el Animator tiene un trigger llamado "StartTransition"
        }

        // Fade out de la música
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

            // Asegura que el volumen final sea 0
            musicSource.volume = 0f;
        }

        // Espera a que la animación termine antes de cargar la escena
        if (transitionAnimator != null)
        {
            yield return new WaitForSeconds(transitionAnimator.GetCurrentAnimatorStateInfo(0).length);
        }

        // Cargar la nueva escena
        SceneManager.LoadScene(sceneName);
    }
}
