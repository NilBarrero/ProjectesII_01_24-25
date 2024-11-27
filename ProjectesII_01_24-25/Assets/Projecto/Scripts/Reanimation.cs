using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reanimation : MonoBehaviour
{
    public int counter = 0;
    // Start is called before the first frame update
    void Update()
    {
        if (counter >= 30)
        {
            SceneManager.LoadScene("Transition Scene");
            Transition.puntuacion += 100;
        }
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        counter++;
    }

}
