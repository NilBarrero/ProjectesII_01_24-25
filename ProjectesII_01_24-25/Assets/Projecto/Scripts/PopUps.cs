using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUps : MonoBehaviour
{
    [Header("Configuraci�n")]
    public List<GameObject> objetosParaSpawnear;
    public float intervaloDeSpawn = 2f;
    public float delayInicial = 1f;

    [Header("Canvas")]
    public RectTransform canvasRect; // Aseg�rate de asignar el Canvas aqu� en el inspector
    public Vector2 padding = new Vector2(100f, 100f); // Margen para evitar que salgan fuera de la vista

    void Start()
    {
        StartCoroutine(SpawnearConDelay());
    }

    IEnumerator SpawnearConDelay()
    {
        yield return new WaitForSeconds(delayInicial);

        while (true)
        {
            SpawnearObjeto();
            yield return new WaitForSeconds(intervaloDeSpawn);
        }
    }

    void SpawnearObjeto()
    {
        if (objetosParaSpawnear.Count == 0 || canvasRect == null) return;

        int indice = Random.Range(0, objetosParaSpawnear.Count);
        GameObject prefab = objetosParaSpawnear[indice];

        // Instanciar como hijo del Canvas
        GameObject instancia = Instantiate(prefab, canvasRect);
        RectTransform rt = instancia.GetComponent<RectTransform>();

        // Calcular �rea del canvas con padding
        float ancho = canvasRect.rect.width;
        float alto = canvasRect.rect.height;

        float x = Random.Range(-ancho / 2f + padding.x, ancho / 2f - padding.x);
        float y = Random.Range(-alto / 2f + padding.y, alto / 2f - padding.y);

        rt.anchoredPosition = new Vector2(x, y); // Posici�n relativa al canvas
    }
}