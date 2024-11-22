using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lifes : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI lifes;
    [SerializeField] private GameObject life1;
    [SerializeField] private GameObject life2;
    [SerializeField] private GameObject life3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLifes();
    }

    void UpdateLifes()
    {
        lifes.text = "Lifes: " + Transition.lifes.ToString();
        
        if (Transition.lifes == 2)
        {
            life1.SetActive(false);
        }

        if (Transition.lifes == 1)
        {
            life1.SetActive(false);
            life2.SetActive(false);
        }

        if (Transition.lifes == 0)
        {
            life1.SetActive(false);
            life2.SetActive(false);
            life3.SetActive(false);
        }

        if(Transition.lifes == 3) 
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
        }
    }
}
