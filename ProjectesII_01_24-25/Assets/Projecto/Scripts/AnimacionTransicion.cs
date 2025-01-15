using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimacionTransicion : MonoBehaviour
{
    private Animator transition;
    public string scene;
    void Start()
    {
        transition = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        StartCoroutine(SceneChange());
    }

    public IEnumerator SceneChange()
    {
        transition.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }
}
