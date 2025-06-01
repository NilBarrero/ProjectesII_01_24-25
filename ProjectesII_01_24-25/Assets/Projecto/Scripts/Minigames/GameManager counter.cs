using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagercounter : MonoBehaviour
{
    public int clickCount = 0;
    public int maxCount = 6;
    public string scene1;
    public string scene2;
    public string scene3;
    public Animator transitionAnimator;  
    public AudioSource musicSource;      
    public float fadeOutDuration = 1f;   
    public bool dontKillCertainNumOfEnemies = false;
    public Timer timer;                  
    private int numOfScene;

    private void Update()
    {
        if (timer.tiempoRestante == 0 && dontKillCertainNumOfEnemies && clickCount > 0)
        {
            numOfScene = 0;
            StartCoroutine(TransitionToScene(scene1));
        }
        else if (clickCount == maxCount)
        {
            numOfScene = 1;
            StartCoroutine(TransitionToScene(scene2));
        }
        else if (timer.tiempoRestante == 0 && clickCount == 0)
        {
            numOfScene = 2;
            StartCoroutine(TransitionToScene(scene3));
        }
    }

    public void IncrementClickCount()
    {
        clickCount++;
        Debug.Log("Clicks: " + clickCount); 
    }

    private IEnumerator TransitionToScene(string sceneName)
    {
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("StartTransition");
        }

        // Fade out the music
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

            musicSource.volume = 0f;
        }

        // Wait for the animation time before changing the scene
        if (transitionAnimator != null)
        {
            yield return new WaitForSeconds(transitionAnimator.GetCurrentAnimatorStateInfo(0).length);
        }

        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        SceneManager.LoadScene(sceneName);
    }
}
