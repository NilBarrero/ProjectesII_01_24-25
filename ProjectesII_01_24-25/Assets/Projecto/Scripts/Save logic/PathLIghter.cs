using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LeerNumeros : MonoBehaviour
{
    private string saveFilePath; // Ruta del archivo de guardado
    public List<int> unlockedScenes = new List<int>(); // Lista para almacenar las IDs de las escenas desbloqueadas
    public List<GameObject> gameObjectsList;

    void Start()
    {
        // Definimos la ruta del archivo de guardado
        saveFilePath = Application.persistentDataPath + "/Path.txt";
        Debug.Log("Save File Path: " + saveFilePath);
        if (File.Exists(saveFilePath))
        {
            string fileContent = File.ReadAllText(saveFilePath);
            Debug.Log("File Content: " + fileContent);  // Verifica el contenido
        }
        else
        {
            Debug.LogWarning("El archivo de guardado no existe.");
        }

        // Cargamos las escenas desbloqueadas desde el archivo
        LoadUnlockedScenes();

    }

    // Método para cargar las escenas desbloqueadas desde el archivo
    void LoadUnlockedScenes()
    {
        if (File.Exists(saveFilePath)) // Verificamos si el archivo existe
        {
            // Leemos todo el contenido del archivo de texto
            string fileContent = File.ReadAllText(saveFilePath);

            // Separamos el contenido usando el espacio como delimitador
            string[] sceneIDs = fileContent.Split(' ');

            // Convertimos cada fragmento (que es una ID de escena) a un número entero y lo añadimos a la lista si está dentro del rango
            foreach (string sceneID in sceneIDs)
            {
                // Aseguramos que no haya entradas vacías (por si hay espacios al final)
                if (!string.IsNullOrWhiteSpace(sceneID))
                {
                    int sceneIDInt = int.Parse(sceneID); // Convertimos la ID a número entero

                    // Verificamos si la escena está dentro del rango permitido (de 5 a 59)
                    if (sceneIDInt >= 0 && sceneIDInt <= 60)
                    {
                        unlockedScenes.Add(sceneIDInt); // Añadimos la ID a la lista
                        Debug.Log("Scene: " + sceneIDInt);

                        // Usamos el sceneIDInt directamente como índice
                        // Verificamos que la ID sea un índice válido para gameObjectsList
                        if (sceneID != null) //Scene null
                        {
                        gameObjectsList[sceneIDInt].SetActive(true); // Activamos el GameObject correspondiente
                        Debug.Log("SceneID set active: " + sceneID);
                        }
                        else
                        {
                            Debug.LogWarning("No hay un GameObject en la posición correspondiente a la escena ID: " + sceneIDInt);
                        }
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("El archivo de guardado no existe. (Check file path in PathLighter Script!)");
        }
    }

    void AsociateEveryGameObjectToSceneID()
    {
        foreach (var obj in gameObjectsList)
        {
            // Ejemplo: Activar/desactivar cada objeto en la lista
            obj.SetActive(false); // Por ejemplo, desactivamos todos los objetos
        }
    }
    

    // Método para verificar si una escena está desbloqueada
    public bool IsSceneUnlocked(int sceneID)
    {
        return unlockedScenes.Contains(sceneID); // Verificamos si la ID está en la lista
    }
}