using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectPrefab : MonoBehaviour
{
    public string prefabName;
    public string prefabName2;
    public string scene;
    public string scene1;
    public bool revertedCollisionPropeties;
    public bool isCollisioning = false;
    public MouseDrag mouseDrag;
    public GameObject object1;
    public GameObject object2;
    // Referencia al Animator que controla la animaci�n
    public Animator animator;
    public bool isBox = false;

    // Referencia al AudioSource de la m�sica
    public AudioSource musicSource;
    public float fadeOutDuration = 2f; // Duraci�n del fade out

    // Referencia al AudioSource para efectos de sonido
    public AudioSource sfxSource;

    private bool isTransitioning = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("�Colisi�n detectada con " + collision.gameObject.name + "!");

        isCollisioning = true; // Se activa para cualquier colisi�n

        // Si el objeto tiene MouseDrag, bloqueamos su movimiento
        MouseDrag mouseDrag = collision.gameObject.GetComponent<MouseDrag>();
        

        // Verifica si el objeto detectado tiene el mismo nombre que el prefab esperado
        if (!revertedCollisionPropeties)
        {
            if (!mouseDrag.isBeingHeld && !isTransitioning && (collision.gameObject.name == prefabName))
            {
                Debug.Log(collision.gameObject.name);
                // Reproduce el efecto de sonido
                PlayDetectionSound();
                
                StartCoroutine(TransitionToScene(scene, object1));
            
            }
            if (!mouseDrag.isBeingHeld && !isTransitioning && (collision.gameObject.name == prefabName2))
            {
                Debug.Log(collision.gameObject.name);
                // Reproduce el efecto de sonido
                PlayDetectionSound();
                if (!isBox)
                    Destroy(object2);
                StartCoroutine(TransitionToScene(scene1, object2));
               
            }
        }
        else
        {
            if (!isTransitioning && (collision.gameObject.name == prefabName))
            {
                Debug.Log(collision.gameObject.name);
                // Reproduce el efecto de sonido
                isCollisioning = true;
                PlayDetectionSound();
                if(!isBox)
                Destroy(object1);
                StartCoroutine(TransitionToScene(scene, object1));
            
            }
            if (!isTransitioning && (collision.gameObject.name == prefabName2))
            {
                Debug.Log(collision.gameObject.name);
                // Reproduce el efecto de sonido
                isCollisioning = true;
                PlayDetectionSound();
                if (!isBox)
                    Destroy(object2);
                StartCoroutine(TransitionToScene(scene1, object2));
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Aqu� verificamos si el objeto sigue dentro del �rea del trigger
        if (mouseDrag == null)
        {
            Debug.Log("MouseDrag isn't inicialized properly");
        }

        // Verifica si el objeto sigue dentro del �rea
        if (!revertedCollisionPropeties)
        {
            if (!mouseDrag.isBeingHeld && !isTransitioning && (collision.gameObject.name == prefabName))
            {
                Debug.Log(collision.gameObject.name);
                // Reproduce el efecto de sonido
                PlayDetectionSound();
                StartCoroutine(TransitionToScene(scene, object1));
            }
            if (!mouseDrag.isBeingHeld && !isTransitioning && (collision.gameObject.name == prefabName2))
            {
                Debug.Log(collision.gameObject.name);
                // Reproduce el efecto de sonido
                PlayDetectionSound();
                StartCoroutine(TransitionToScene(scene1, object2));
            }
        }
        else
        {
            if (!isTransitioning && (collision.gameObject.name == prefabName))
            {
                Debug.Log(collision.gameObject.name);
                // Reproduce el efecto de sonido
                PlayDetectionSound();
                StartCoroutine(TransitionToScene(scene, object1));
            }
            if (!isTransitioning && (collision.gameObject.name == prefabName2))
            {
                Debug.Log(collision.gameObject.name);
                // Reproduce el efecto de sonido
                PlayDetectionSound();
                StartCoroutine(TransitionToScene(scene1, object2));
            }
        }
    }

    private IEnumerator TransitionToScene(string scene, GameObject object1)
    {
        if (!isBox)
            Destroy(object1);
        isTransitioning = true; // Evita llamadas m�ltiples

        // Fade out de la m�sica
        if (musicSource != null)
        {
            yield return StartCoroutine(FadeOutMusic());
        }

        // Animaci�n de transici�n
        if (animator != null)
        {
            animator.SetTrigger("StartTransition"); // Activa la animaci�n
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length); // Espera el tiempo de la animaci�n
        }

        // Cambia de escena
        SceneManager.LoadScene(scene);
    }

    private IEnumerator FadeOutMusic()
    {
        float startVolume = musicSource.volume;

        // Reduce el volumen de la m�sica durante un tiempo
        float timeElapsed = 0f;
        while (timeElapsed < fadeOutDuration)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0f, timeElapsed / fadeOutDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Asegura que el volumen llegue a 0
        musicSource.volume = 0f;
    }

    private void PlayDetectionSound()
    {
        if (sfxSource != null)
        {
            sfxSource.Play();
        }
    }
}

