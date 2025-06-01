using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CountingEndings : MonoBehaviour
{
    public int maxNumber;
    public TextMeshProUGUI text;
    private int activeEndings;
    public int startingNumber;
    public int numberOfEndings;
    public int endings;
    void Start()
    {
        for (; startingNumber < (maxNumber+1); startingNumber++)
        {
           if ( PlayerPrefs.GetInt(startingNumber.ToString(), 0) != 0)
                activeEndings++;
           endings++;

        }

        text.text = activeEndings + "/" + numberOfEndings;
        Debug.Log(endings + " Endings\n" + activeEndings + " activeEndings");
        if ((endings -1) == activeEndings)
        {
            text.color = Color.green;
        }

    }


    void Update()
    {
        
    }
}
