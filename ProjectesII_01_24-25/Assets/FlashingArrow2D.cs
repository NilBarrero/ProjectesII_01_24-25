using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingArrow2D : MonoBehaviour
{
    public float flashInterval = 0.5f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        while (true)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(flashInterval);
        }
    }
}
