using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadNumbers : MonoBehaviour
{
    public int numberOfElements = 75;
    private string saveFilePath; // Path to the save file
    public List<int> unlockedScenes = new List<int>(); // List to store the unlocked scene IDs
    public List<GameObject> gameObjectsList;
    public bool tutorialFinal = false;

    void Start()
    {
        // Define the save file path
        saveFilePath = Application.persistentDataPath + "/Path.txt";
        Debug.Log("Save File Path: " + saveFilePath);
        if (File.Exists(saveFilePath))
        {
            string fileContent = File.ReadAllText(saveFilePath);
            Debug.Log("File Content: " + fileContent);  // Verify the content
        }
        else
        {
            Debug.LogWarning("The save file does not exist.");
        }

        // Load the unlocked scenes from the file
        LoadUnlockedScenes();
    }

    // Method to load unlocked scenes from the file
    void LoadUnlockedScenes()
    {
        if (File.Exists(saveFilePath)) // Check if the file exists
        {
            if (tutorialFinal)
            {
                gameObjectsList[69].SetActive(true);
                gameObjectsList[70].SetActive(true);
                gameObjectsList[71].SetActive(true);
            }

            // Read all content from the text file
            string fileContent = File.ReadAllText(saveFilePath);

            // Split the content using space as a delimiter
            string[] sceneIDs = fileContent.Split(' ');

            // Convert each fragment (which is a scene ID) to an integer and add it to the list if it's within range
            foreach (string sceneID in sceneIDs)
            {
                // Ensure there are no empty entries (in case there are trailing spaces)
                if (!string.IsNullOrWhiteSpace(sceneID))
                {
                    int sceneIDInt = int.Parse(sceneID); // Convert the ID to an integer

                    // Check if the scene ID is within the allowed range (from 0 to numberOfElements)
                    if (sceneIDInt >= 0 && sceneIDInt <= numberOfElements)
                    {
                        unlockedScenes.Add(sceneIDInt); // Add the ID to the list
                        Debug.Log("Scene: " + sceneIDInt);

                        // Use the sceneIDInt directly as an index
                        // Verify that the ID is a valid index for gameObjectsList
                        if (sceneID != null) // Scene null check
                        {
                            gameObjectsList[sceneIDInt].SetActive(true); // Activate the corresponding GameObject
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
            // Example: Activate/deactivate each object in the list
            obj.SetActive(false); // For example, deactivate all objects
        }
    }


    // Method to check if a scene is unlocked
    public bool IsSceneUnlocked(int sceneID)
    {
        return unlockedScenes.Contains(sceneID); // Check if the ID is in the list
    }
}
