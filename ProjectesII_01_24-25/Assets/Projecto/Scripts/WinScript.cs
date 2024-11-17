using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnMouseDown()
    {
        SceneManager.LoadScene("WinScene");
    }

    private void OnMouseUp()
    {
        
    }

}
