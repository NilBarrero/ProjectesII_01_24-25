using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Timer : MonoBehaviour
{
    public int tiempoInicial = 30; //secons
    public int tiempoRestante; 
    private float tiempoTranscurrido; 
    public TextMeshProUGUI textoCuentaRegresiva;
  
    public string scene; 
    public bool destroyTrash = false; 
    public GameManagercounter counter; 

    // Variables for animation and music
    public Animator transitionAnimator;  
    public AudioSource musicSource;      
    public float fadeOutDuration = 1f;   

    void Start()
    {
        tiempoRestante = tiempoInicial; 
        tiempoTranscurrido = 0f; 
        ActualizarTexto(); 
    }

    void Update()
    {
        if (tiempoRestante > 0)
        {
            tiempoTranscurrido += Time.deltaTime; 

            if (tiempoTranscurrido >= 1f) 
            {
                tiempoRestante--; 
                tiempoTranscurrido = 0f; 
                ActualizarTexto(); 
            }
        }

        if (tiempoRestante > 7)
        {
            textoCuentaRegresiva.color = Color.green;
        }
        else if (tiempoRestante <= 7 && tiempoRestante > 3)
        {
            textoCuentaRegresiva.color = Color.yellow;
        }
        else if (tiempoRestante <= 3)
        {
            textoCuentaRegresiva.color = Color.red;
        }

        if (tiempoRestante == 0)
        {
            StartCoroutine(TransitionToScene()); 
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

    void ActualizarTexto()
    {
        textoCuentaRegresiva.text = tiempoRestante.ToString() + " s";
    }
}

