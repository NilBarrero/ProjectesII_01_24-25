using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public Animator animator; // Asigna el Animator en el Inspector
    public float displayTime = 3f; // Tiempo en pantalla antes de la animación

    void Start()
    {
        StartCoroutine(SplashSequence());
    }

    IEnumerator SplashSequence()
    {
        yield return new WaitForSeconds(displayTime);
        animator.SetTrigger("StartTransition");

        // Espera un poco más para ver si cambia de escena
        yield return new WaitForSeconds(2f);
        LoadNextScene();
    }

    // Este método se llamará al final de la animación
    public void LoadNextScene()
    {
        SceneManager.LoadScene("Menu Principal"); // Cambia de escena
    }
}