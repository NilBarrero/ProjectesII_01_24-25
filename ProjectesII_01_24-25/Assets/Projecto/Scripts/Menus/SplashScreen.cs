using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public Animator animator; // Assign the Animator in the Inspector
    public float displayTime = 3f; // Time on screen before the animation

    void Start()
    {
        StartCoroutine(SplashSequence());
    }

    IEnumerator SplashSequence()
    {
        yield return new WaitForSeconds(displayTime);
        animator.SetTrigger("StartTransition");

        // Wait a bit more to see if the scene changes
        yield return new WaitForSeconds(2f);
        LoadNextScene();
    }

    // This method will be called at the end of the animation
    public void LoadNextScene()
    {
        SceneManager.LoadScene("Menu Principal"); // Change scene
    }
}
