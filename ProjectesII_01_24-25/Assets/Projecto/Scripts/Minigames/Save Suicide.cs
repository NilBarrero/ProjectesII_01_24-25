using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSuicide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Yes()
    {
            SceneManager.LoadScene("1.2.1");
    }

    public void No()
    {
        SceneManager.LoadScene("1.2.2");
    }
}
