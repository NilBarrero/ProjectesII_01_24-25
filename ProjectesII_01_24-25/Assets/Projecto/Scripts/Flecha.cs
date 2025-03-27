using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Flecha : MonoBehaviour
{
    // Start is called before the first frame update
    public int numberOfArrow;
    public GameObject arrow;
    void OnEnable()
    {
        arrow.SetActive(false);
        Debug.Log("Last Scene: " + PlayerPrefs.GetInt("LastScene"));

        if (numberOfArrow == PlayerPrefs.GetInt("LastScene"))
        {
            
            arrow.SetActive(true);
        }
    }

    // Update is called once per frame

}
