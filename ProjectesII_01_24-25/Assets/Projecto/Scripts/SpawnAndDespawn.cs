using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndDespawn : MonoBehaviour
{
    // Prefab del GameObject a spawnear
    public GameObject objectToSpawn;
    public GameObject box;

    // Tiempo en segundos entre cada spawn
    public float spawnInterval = 3f;

    // Tiempo en segundos para que el objeto se destruya
    public float despawnTime = 5f;

    // Posición donde spawnear los objetos
    public Transform spawnPosition;

    // Contador de tiempo
    private float timer;

    // Flag para detener el script
    private bool isStopped = false;

    void Start()
    {
        box.SetActive(false);
        timer = spawnInterval; // Inicializa el contador
    }

    void Update()
    {
        // Si está detenido, no ejecutar nada más
        if (isStopped)
            return;

        timer -= Time.deltaTime; // Reduce el tiempo por cada frame

        if (timer <= 0f)
        {
            Spawn();
            box.SetActive(true);
            timer = spawnInterval; // Reinicia el contador
        }

    }

    void Spawn()
    {
        if (objectToSpawn != null)
        {
            // Instancia el objeto en la posición deseada
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition.position, spawnPosition.rotation);

            // Destruye el objeto después de 'despawnTime' segundos
            Destroy(spawnedObject, despawnTime);

            // Detiene el script cuando el objeto se destruye
            StartCoroutine(StopScriptAfterDespawn(despawnTime));
        }
        else
        {
            Debug.LogWarning("No se ha asignado un GameObject para spawnear.");
        }
    }

    System.Collections.IEnumerator StopScriptAfterDespawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        isStopped = true; // Marca el script como detenido
        Debug.Log("El objeto ha sido destruido. El script se ha detenido.");
    }
}

