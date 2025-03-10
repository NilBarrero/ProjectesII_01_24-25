using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.ParticleSystem;

public class ButtonInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector2 startPos;
    private Vector2 targetPos;
    public float distanciaMov = 10f;
    public float moveSpeed = 0.2f;
    private bool isMoving = false;

    void Start()
    {
        startPos = GetComponent<RectTransform>().anchoredPosition;
        targetPos = startPos + new Vector2(distanciaMov, distanciaMov);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isMoving)
            StartCoroutine(MoveButton(targetPos));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isMoving)
            StartCoroutine(MoveButton(startPos));
    }

    IEnumerator MoveButton(Vector2 newPosition)
    {
        isMoving = true;
        RectTransform rectTransform = GetComponent<RectTransform>();
        float elapsedTime = 0f;
        Vector2 initialPosition = rectTransform.anchoredPosition;

        while (elapsedTime < moveSpeed)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(initialPosition, newPosition, elapsedTime / moveSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = newPosition;
        isMoving = false;
    }
}
