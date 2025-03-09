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
    // Referencia al Animator que controla la animación
    public Animator animator;
    public bool isBox = false;

    // Referencia al AudioSource de la música
    public AudioSource musicSource;
    public float fadeOutDuration = 2f; // Duración del fade out

    // Referencia al AudioSource para efectos de sonido
    public AudioSource sfxSource;

    private bool isTransitioning = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("¡Colisión detectada con " + collision.gameObject.name + "!");

        isCollisioning = true; // Se activa para cualquier colisión

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
        // Aquí verificamos si el objeto sigue dentro del área del trigger
        if (mouseDrag == null)
        {
            Debug.Log("MouseDrag isn't inicialized properly");
        }

        // Verifica si el objeto sigue dentro del área
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
        isTransitioning = true; // Evita llamadas múltiples

        // Fade out de la música
        if (musicSource != null)
        {
            yield return StartCoroutine(FadeOutMusic());
        }

        // Animación de transición
        if (animator != null)
        {
            animator.SetTrigger("StartTransition"); // Activa la animación
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length); // Espera el tiempo de la animación
        }

        // Cambia de escena
        SceneManager.LoadScene(scene);
    }

    private IEnumerator FadeOutMusic()
    {
        float startVolume = musicSource.volume;

        // Reduce el volumen de la música durante un tiempo
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

