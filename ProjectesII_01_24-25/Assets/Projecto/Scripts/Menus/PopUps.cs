using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUps : MonoBehaviour
{
    [Header("Configuración")]
    public List<GameObject> objetosParaSpawnear;
    public float intervaloDeSpawn = 2f;
    public float delayInicial = 1f;

    [Header("Canvas")]
    public RectTransform canvasRect;
    public Vector2 padding = new Vector2(100f, 100f);

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

        GameObject instancia = Instantiate(prefab, canvasRect);
        RectTransform rt = instancia.GetComponent<RectTransform>();

        float ancho = canvasRect.rect.width;
        float alto = canvasRect.rect.height;

        float x = Random.Range(-ancho / 2f + padding.x, ancho / 2f - padding.x);
        float y = Random.Range(-alto / 2f + padding.y, alto / 2f - padding.y);

        rt.anchoredPosition = new Vector2(x, y);
    }
}
