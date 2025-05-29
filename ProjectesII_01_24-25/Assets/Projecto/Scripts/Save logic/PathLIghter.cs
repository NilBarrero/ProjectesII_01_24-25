using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadNumbers : MonoBehaviour
{
    public int numberOfElements = 75;
    private string saveFilePath;
    public List<int> unlockedScenes = new List<int>();
    public List<GameObject> gameObjectsList;
    public bool tutorialFinal = false;

    void Start()
    {
        saveFilePath = Application.persistentDataPath + "/Path.txt";
        Debug.Log("Save File Path: " + saveFilePath);
        if (File.Exists(saveFilePath))
        {
            string fileContent = File.ReadAllText(saveFilePath);
            Debug.Log("File Content: " + fileContent);
        }
        else
        {
            Debug.LogWarning("The save file does not exist.");
        }

        LoadUnlockedScenes();
    }

    void LoadUnlockedScenes()
    {
        if (File.Exists(saveFilePath))
        {
            if (tutorialFinal)
            {
                gameObjectsList[69].SetActive(true);
                gameObjectsList[70].SetActive(true);
                gameObjectsList[71].SetActive(true);
            }

            string fileContent = File.ReadAllText(saveFilePath);
            string[] sceneIDs = fileContent.Split(' ');

            foreach (string sceneID in sceneIDs)
            {
                if (!string.IsNullOrWhiteSpace(sceneID))
                {
                    int sceneIDInt = int.Parse(sceneID);

                    if (sceneIDInt >= 0 && sceneIDInt <= numberOfElements)
                    {
                        unlockedScenes.Add(sceneIDInt);
                        Debug.Log("Scene: " + sceneIDInt);

                        if (sceneID != null)
                        {
                            gameObjectsList[sceneIDInt].SetActive(true);
                            Debug.Log("SceneID set active: " + sceneID);
                        }
                        else
                        {
                            Debug.LogWarning("There is no GameObject at the position corresponding to Scene ID: " + sceneIDInt);
                        }
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("The save file does not exist. (Check file path in PathLighter Script!)");
        }
    }

    void AssociateEveryGameObjectToSceneID()
    {
        foreach (var obj in gameObjectsList)
        {
            obj.SetActive(false);
        }
    }



    public bool IsSceneUnlocked(int sceneID)
    {
        return unlockedScenes.Contains(sceneID);
    }
}
