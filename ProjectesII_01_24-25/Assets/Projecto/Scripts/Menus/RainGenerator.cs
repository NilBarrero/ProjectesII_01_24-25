using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainGenerator : MonoBehaviour
{
    public GameObject rainPrefab; // Prefab with the RainImage script
    public RectTransform parentCanvas; // Canvas or UI panel where to instantiate
    public float spawnInterval = 0.2f; // Time between each raindrop
    public int maxRaindrops = 100;     // Maximum number of active raindrops

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

        // Random position at the top of the canvas
        float x = Random.Range(-parentCanvas.rect.width / 2f, parentCanvas.rect.width / 2f);
        float y = Random.Range(parentCanvas.rect.height / 2f, parentCanvas.rect.height / 2f + 150f);
        rect.anchoredPosition = new Vector2(x, y);

        currentCount++;
    }
}
