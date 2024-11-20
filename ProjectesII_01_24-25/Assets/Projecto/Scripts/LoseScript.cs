using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnMouseDown()
    {
        if (Transition.lifes > 0)
        {
            Transition.lifes--;
        }
        SceneManager.LoadScene("Transition Scene");
    }

    private void OnMouseUp()
    {

    }
}
