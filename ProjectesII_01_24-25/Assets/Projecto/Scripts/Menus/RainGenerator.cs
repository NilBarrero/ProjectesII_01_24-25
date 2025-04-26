using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainGenerator : MonoBehaviour
{
    public GameObject rainPrefab; // Prefab con el script RainImage
    public RectTransform parentCanvas; // Canvas o panel UI donde instanciar
    public float spawnInterval = 0.2f; // Tiempo entre cada gota
    public int maxRaindrops = 100;     // Máximo de gotas activas

    private int currentCount = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnRaindrop), 0f, spawnInterval);
    }

    void SpawnRaindrop()
    {
        if (currentCount >= maxRaindrops) return;

        GameObject newDrop = Instantiate(rainPrefab, parentCanvas);
        RectTransform rect = newDrop.GetComponent<RectTransform>();

        // Posición aleatoria en la parte superior del canvas
        float x = Random.Range(-parentCanvas.rect.width / 2f, parentCanvas.rect.width / 2f);
        float y = Random.Range(parentCanvas.rect.height / 2f, parentCanvas.rect.height / 2f + 150f);
        rect.anchoredPosition = new Vector2(x, y);

        currentCount++;
    }
}