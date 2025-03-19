using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CountingEndings : MonoBehaviour
{
    public int maxNumber;
    public TextMeshProUGUI text;
    private int activeEndings;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < (maxNumber+1); i++)
        {
           if ( PlayerPrefs.GetInt(i.ToString(), 0) != 0)
                activeEndings++;
        }

        text.text = activeEndings + "/17";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
