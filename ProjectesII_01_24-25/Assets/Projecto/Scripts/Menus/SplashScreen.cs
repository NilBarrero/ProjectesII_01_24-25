using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public Animator animator; // Asigna el Animator en el Inspector
    public float displayTime = 3f; // Tiempo en pantalla antes de la animaci�n

    void Start()
    {
        StartCoroutine(SplashSequence());
    }

    IEnumerator SplashSequence()
    {
        yield return new WaitForSeconds(displayTime);
        animator.SetTrigger("StartTransition");

        // Espera un poco m�s para ver si cambia de escena
        yield return new WaitForSeconds(2f);
        LoadNextScene();
    }

    // Este m�todo se llamar� al final de la animaci�n
    public void LoadNextScene()
    {
        SceneManager.LoadScene("Menu Principal"); // Cambia de escena
    }
}