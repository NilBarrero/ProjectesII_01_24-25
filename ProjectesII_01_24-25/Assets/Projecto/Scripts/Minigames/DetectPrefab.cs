using System.Collections;
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
    public Animator animator;
    public bool isBox = false;

    public AudioSource musicSource;
    public float fadeOutDuration = 2f;

    public AudioClip detectionSound; // Sound effect when the prefab is detected

    private bool isTransitioning = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name + "!");
        isCollisioning = true;

        MouseDrag mouseDrag = collision.gameObject.GetComponent<MouseDrag>();

        if (!revertedCollisionPropeties)
        {
            if (!mouseDrag.isBeingHeld && !isTransitioning && (collision.gameObject.name == prefabName))
            {
                PlayDetectionSound();
                StartCoroutine(TransitionToScene(scene, object1));
            }
            if (!mouseDrag.isBeingHeld && !isTransitioning && (collision.gameObject.name == prefabName2))
            {
                PlayDetectionSound();
                if (!isBox) Destroy(object2);
                StartCoroutine(TransitionToScene(scene1, object2));
            }
        }
        else
        {
            if (!isTransitioning && (collision.gameObject.name == prefabName))
            {
                isCollisioning = true;
                PlayDetectionSound();
                if (!isBox) Destroy(object1);
                StartCoroutine(TransitionToScene(scene, object1));
            }
            if (!isTransitioning && (collision.gameObject.name == prefabName2))
            {
                isCollisioning = true;
                PlayDetectionSound();
                if (!isBox) Destroy(object2);
                StartCoroutine(TransitionToScene(scene1, object2));
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (mouseDrag == null)
        {
            Debug.Log("MouseDrag isn't initialized properly");
        }

        if (!revertedCollisionPropeties)
        {
            if (!mouseDrag.isBeingHeld && !isTransitioning && (collision.gameObject.name == prefabName))
            {
                PlayDetectionSound();
                StartCoroutine(TransitionToScene(scene, object1));
            }
            if (!mouseDrag.isBeingHeld && !isTransitioning && (collision.gameObject.name == prefabName2))
            {
                PlayDetectionSound();
                StartCoroutine(TransitionToScene(scene1, object2));
            }
        }
        else
        {
            if (!isTransitioning && (collision.gameObject.name == prefabName))
            {
                PlayDetectionSound();
                StartCoroutine(TransitionToScene(scene, object1));
            }
            if (!isTransitioning && (collision.gameObject.name == prefabName2))
            {
                PlayDetectionSound();
                StartCoroutine(TransitionToScene(scene1, object2));
            }
        }
    }

    private IEnumerator TransitionToScene(string scene, GameObject object1)
    {
        if (!isBox) Destroy(object1);
        isTransitioning = true;

        if (musicSource != null)
        {
            yield return StartCoroutine(FadeOutMusic());
        }

        if (animator != null)
        {
            animator.SetTrigger("StartTransition");
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        }

        SceneManager.LoadScene(scene);
    }

    private IEnumerator FadeOutMusic()
    {
        float startVolume = musicSource.volume;
        float timeElapsed = 0f;

        while (timeElapsed < fadeOutDuration)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0f, timeElapsed / fadeOutDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        musicSource.volume = 0f;
    }

    private void PlayDetectionSound()
    {
        if (detectionSound != null)
        {
            AudioManager.instance.PlaySFX(detectionSound);
        }
    }
}
