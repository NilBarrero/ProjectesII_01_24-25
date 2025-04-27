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
    public Animator transitionAnimator;  // Reference to the Animator for the transition animation
    public AudioSource musicSource;      // Reference to the music source
    public float fadeOutDuration = 1f;   // Duration of the fade-out for the music
    public bool dontKillCertainNumOfEnemies = false;
    public Timer timer;                  // Reference to the Timer script
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
        Debug.Log("Clicks: " + clickCount); // Logs the click count to the console
    }

    private IEnumerator TransitionToScene(string sceneName)
    {
        // Start the transition animation
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

            // Ensure the final volume is 0
            musicSource.volume = 0f;
        }

        // Wait for the animation time before changing the scene
        if (transitionAnimator != null)
        {
            yield return new WaitForSeconds(transitionAnimator.GetCurrentAnimatorStateInfo(0).length);
        }

        // **Reset the cursor before changing the scene**
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        // Load the new scene
        SceneManager.LoadScene(sceneName);
    }
}
