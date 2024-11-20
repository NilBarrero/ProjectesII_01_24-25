using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lifes : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI lifes;
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
    }
}
