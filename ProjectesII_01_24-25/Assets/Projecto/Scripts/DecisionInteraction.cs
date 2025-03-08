using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionInteraction : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 targetPos;
    public float distanciaMov = 0.2f; // Ajusta la distancia del movimiento
    public float moveSpeed = 0.1f;
    private bool isMoving = false;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + new Vector2(distanciaMov, distanciaMov);
    }

    void OnMouseEnter()
    {
        if (!isMoving)
            StartCoroutine(MoveSprite(targetPos));
    }

    void OnMouseExit()
    {
        if (!isMoving)
            StartCoroutine(MoveSprite(startPos));
    }

    IEnumerator MoveSprite(Vector2 newPosition)
    {
        isMoving = true;
        float elapsedTime = 0f;
        Vector2 initialPosition = transform.position;

        while (elapsedTime < moveSpeed)
        {
            transform.position = Vector2.Lerp(initialPosition, newPosition, elapsedTime / moveSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = newPosition;
        isMoving = false;
    }
}
