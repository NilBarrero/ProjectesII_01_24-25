using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LeerNumeros : MonoBehaviour
{
    public int numberOfElements = 75;
    private string saveFilePath; // Ruta del archivo de guardado
    public List<int> unlockedScenes = new List<int>(); // Lista para almacenar las IDs de las escenas desbloqueadas
    public List<GameObject> gameObjectsList;
    public bool tutorialFinal = false;

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

    // M�todo para cargar las escenas desbloqueadas desde el archivo
    void LoadUnlockedScenes()
    {
        if (File.Exists(saveFilePath)) // Verificamos si el archivo existe
        {
            if (tutorialFinal)
            {
                gameObjectsList[69].SetActive(true);
                gameObjectsList[70].SetActive(true);
                gameObjectsList[71].SetActive(true);
            }

            // Leemos todo el contenido del archivo de texto
            string fileContent = File.ReadAllText(saveFilePath);

            // Separamos el contenido usando el espacio como delimitador
            string[] sceneIDs = fileContent.Split(' ');

            // Convertimos cada fragmento (que es una ID de escena) a un n�mero entero y lo a�adimos a la lista si est� dentro del rango
            foreach (string sceneID in sceneIDs)
            {
                // Aseguramos que no haya entradas vac�as (por si hay espacios al final)
                if (!string.IsNullOrWhiteSpace(sceneID))
                {
                    int sceneIDInt = int.Parse(sceneID); // Convertimos la ID a n�mero entero

                    // Verificamos si la escena est� dentro del rango permitido (de 5 a 59)
                    if (sceneIDInt >= 0 && sceneIDInt <= numberOfElements)
                    {
                        unlockedScenes.Add(sceneIDInt); // A�adimos la ID a la lista
                        Debug.Log("Scene: " + sceneIDInt);

                        // Usamos el sceneIDInt directamente como �ndice
                        // Verificamos que la ID sea un �ndice v�lido para gameObjectsList
                        if (sceneID != null) //Scene null
                        {
                        gameObjectsList[sceneIDInt].SetActive(true); // Activamos el GameObject correspondiente
                        Debug.Log("SceneID set active: " + sceneID);
                        }
                        else
                        {
                            Debug.LogWarning("No hay un GameObject en la posici�n correspondiente a la escena ID: " + sceneIDInt);
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
    

    // M�todo para verificar si una escena est� desbloqueada
    public bool IsSceneUnlocked(int sceneID)
    {
        return unlockedScenes.Contains(sceneID); // Verificamos si la ID est� en la lista
    }
}