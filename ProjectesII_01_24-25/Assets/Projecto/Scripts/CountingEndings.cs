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
    // Start is called before the first frame update
    void Start()
    {
        for (; startingNumber < (maxNumber+1); startingNumber++)
        {
           if ( PlayerPrefs.GetInt(startingNumber.ToString(), 0) != 0)
                activeEndings++;
        }

        text.text = activeEndings + "/" + numberOfEndings;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
