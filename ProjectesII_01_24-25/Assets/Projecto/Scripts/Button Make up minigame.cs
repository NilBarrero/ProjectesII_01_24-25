using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class ButtonMakeupminigame : MonoBehaviour
{
    // Start is called before the first frame updateº
    public Detectifitsxory detect;
    private string entregaPerfecta = "EntregaPerfecta3rd";
    private string entregaMediocre = "entregaMediocre3rd";
    private string entregaErronea = "entregaErronea3rd";

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (detect.numOfObjects == 2 || detect.numOfObjects == 1 || detect.numOfObjects == 0)
        {
            SceneManager.LoadScene(entregaMediocre);
        }
        else if (detect.numOfObjects == 3)
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
