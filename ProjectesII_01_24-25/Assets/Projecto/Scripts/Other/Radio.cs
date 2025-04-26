using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Radio : MonoBehaviour
{
    public TextMeshProUGUI counterText; // Arrastra el texto aqu� desde el inspector
    private int counter = 0;
    public string scene;
    int win = 100;

    // M�todo para incrementar
    public void Increment()
    {
            counter++;
        
        UpdateCounterText();
    }

    // M�todo para decrementar
    public void Decrement()
    {
        if (counter > 0)
        {
            counter--;
        }
        else
        {
            counter = 100;
        }
        
        UpdateCounterText();
    }

    // Actualiza el texto del contador
    private void UpdateCounterText()
    {
        if (counter == win)
        {
            SceneManager.LoadScene(scene);
        }
        counterText.text = counter.ToString();
    }
}
