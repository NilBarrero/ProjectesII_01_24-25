using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hit : MonoBehaviour
{
    public int hits;
    public GameObject[] bloodB;
    public GameObject[] bloodC;
    private int next = 0;
    int punchs = 4;
    int fhinish = 14;
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        hits++;
        bloodB[next].SetActive(true);
        next++;

        if (hits >= punchs)
        {
            bloodC[next].SetActive(true);
        }

        if (hits >= fhinish)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
