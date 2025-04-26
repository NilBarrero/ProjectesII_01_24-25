using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainImage : MonoBehaviour
{
    public float minSpeed = 100f; // In pixels per second
    public float maxSpeed = 300f;
    public Sprite[] sprites;

    public float zigzagAmplitude = 50f;   // In pixels
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

        // Random sprite
        if (sprites.Length > 0)
            image.sprite = sprites[Random.Range(0, sprites.Length)];

        // Random scale
        float scale = Random.Range(0.5f, 1.2f);
        rectTransform.localScale = Vector3.one * scale;

        // Random transparency
        float alpha = 0.33f;
        image.color = new Color(1f, 1f, 1f, alpha);

        // Speed
        speed = Random.Range(minSpeed, maxSpeed);

        // Screen size (Canvas in Screen Space mode)
        screenHeight = ((RectTransform)rectTransform.parent).rect.height;
        screenWidth = ((RectTransform)rectTransform.parent).rect.width;

        // Initial position
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
            // Reset to top
            float randomX = Random.Range(-screenWidth / 2f, screenWidth / 2f);
            float randomY = screenHeight / 2f + Random.Range(50f, 150f);
            rectTransform.anchoredPosition = new Vector2(randomX, randomY);
            startPosition = rectTransform.anchoredPosition;
            timeOffset = Random.Range(0f, 2f * Mathf.PI);

            // New visual properties
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
