using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainImage : MonoBehaviour
{
    public float minSpeed = 100f; // En píxeles por segundo
    public float maxSpeed = 300f;
    public Sprite[] sprites;

    public float zigzagAmplitude = 50f;   // En píxeles
    public float zigzagFrequency = 2f;

    private float speed;
    private float screenHeight;
    private float screenWidth;
    private Image image;
    private RectTransform rectTransform;
    private Vector2 startPosition;
    private float timeOffset;

    void Start()
    {
        image = GetComponent<Image>();
        image.raycastTarget = false;
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();

        // Sprite aleatorio
        if (sprites.Length > 0)
            image.sprite = sprites[Random.Range(0, sprites.Length)];

        // Escala aleatoria
        float scale = Random.Range(0.5f, 1.2f);
        rectTransform.localScale = Vector3.one * scale;

        // Transparencia aleatoria
        float alpha = 0.33f;
        image.color = new Color(1f, 1f, 1f, alpha);

        // Velocidad
        speed = Random.Range(minSpeed, maxSpeed);

        // Tamaño de pantalla (Canvas en modo Screen Space)
        screenHeight = ((RectTransform)rectTransform.parent).rect.height;
        screenWidth = ((RectTransform)rectTransform.parent).rect.width;

        // Posición inicial
        startPosition = rectTransform.anchoredPosition;
        timeOffset = Random.Range(0f, 2f * Mathf.PI);
    }

    void Update()
    {
        float newY = rectTransform.anchoredPosition.y - speed * Time.deltaTime;
        float newX = startPosition.x + Mathf.Sin(Time.time * zigzagFrequency + timeOffset) * zigzagAmplitude;

        rectTransform.anchoredPosition = new Vector2(newX, newY);

        if (newY < -screenHeight / 2f - 100f)
        {
            // Reiniciar arriba
            float randomX = Random.Range(-screenWidth / 2f, screenWidth / 2f);
            float randomY = screenHeight / 2f + Random.Range(50f, 150f);
            rectTransform.anchoredPosition = new Vector2(randomX, randomY);
            startPosition = rectTransform.anchoredPosition;
            timeOffset = Random.Range(0f, 2f * Mathf.PI);

            // Nuevas propiedades visuales
            if (sprites.Length > 0)
                image.sprite = sprites[Random.Range(0, sprites.Length)];

            float scale = Random.Range(0.5f, 1.2f);
            rectTransform.localScale = Vector3.one * scale;

            float alpha = 0.33f;
            image.color = new Color(1f, 1f, 1f, alpha);

            speed = Random.Range(minSpeed, maxSpeed);
        }
    }
}
