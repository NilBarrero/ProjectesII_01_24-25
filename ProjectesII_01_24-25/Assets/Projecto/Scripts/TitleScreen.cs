using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip animacionFinal;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Play()
    {
        StartCoroutine(Animation());
    }
    
    IEnumerator Animation()
    {
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }
}