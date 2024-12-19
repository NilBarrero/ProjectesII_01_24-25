using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class ButtonMakeupminigame : MonoBehaviour
{
    // Start is called before the first frame updateº
    public Detectifitsxory detect;
    private string entregaPerfecta = "entregaPerfecta 3rd";
    private string entregaMediocre = "entregaMediocre 3rd";
    private string entregaErronea = "entregaErronea 3rd";

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (detect.numOfObjects <= 2)
        {
            SceneManager.LoadScene(entregaMediocre);
        }
        if (detect.numOfObjects < 4)
        {
            Debug.Log("There are ");
            Debug.Log(detect.numOfObjects);
            SceneManager.LoadScene(entregaPerfecta);

        }
        else
        {
            Debug.Log("There are 4");
            SceneManager.LoadScene(entregaErronea);

        }
    }
}
