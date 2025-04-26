using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionInteraction : MonoBehaviour
{
    private Vector3 startScale;
    private float newScale = 1.25f;
    private Transform transformText;

    void Start()
    {
        transformText = GetComponentInChildren<SpriteRenderer>().transform;
        startScale = transform.localScale;

    }

    void OnMouseEnter()
    {
        transform.localScale = startScale * newScale;
    }

    void OnMouseExit()
    {
        transform.localScale = startScale;
    }

}
