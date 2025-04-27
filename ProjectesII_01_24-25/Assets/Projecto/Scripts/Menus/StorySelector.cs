using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StorySelector : MonoBehaviour
{
    [SerializeField] private FadeInOutMusic fadeMusic; // Reference to the FadeInOutMusic script.
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject storySelector;
    public GameObject deliver1;
    public GameObject deliver1locked;

    public void Start()
    {

        deliver1locked.SetActive(true);
        int finished = PlayerPrefs.GetInt("finished");
        if (finished == 0)
        {
            Debug.LogError("finished = " + finished);
            deliver1.SetActive(true);
            deliver1locked.SetActive(false);

        }
    }

    public void Exit()
    {
        if (menuPrincipal != null)
        {

            menuPrincipal.SetActive(true);
            storySelector.SetActive(false);
        }
    }

    public void Prolog()
    {
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); // Reset cursor before changing scene
        fadeMusic.TriggerSceneChange("MenuTutorial");
    }

    public void FirstJob()
    {
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); // Reset cursor before changing scene
        fadeMusic.TriggerSceneChange("MenuFirstJob");
    }

    public void SecondJob()
    {
        // Second delivery
    }

    public void ThirdJob()
    {
        // Third delivery
    }

    public void ForthJob()
    {
        // Fourth delivery
    }
}
