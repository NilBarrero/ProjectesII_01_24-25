using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentObjectManager : MonoBehaviour
{
    // Dictionary to store which prefab corresponds to which scene
    [System.Serializable]
    public struct PrefabSceneMapping
    {
        public GameObject prefab;
        public string sceneName;
    }

    public PrefabSceneMapping[] prefabToSceneMappings;

    // Singleton instance for easy access
    private static PersistentObjectManager instance;

    // Ensure only one instance exists
    void Awake()
    {
        // If an instance already exists, destroy the new one
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // Set the instance to this object
        instance = this;

        // Make this object persist between scenes
        DontDestroyOnLoad(gameObject);
    }

    // This method is used to instantiate a prefab and load the corresponding scene
    public void InstantiatePrefabAndLoadScene(GameObject prefab)
    {
        // Find the mapping for the prefab
        foreach (PrefabSceneMapping mapping in prefabToSceneMappings)
        {
            if (mapping.prefab == prefab)
            {
                // Instantiate the prefab
                Instantiate(prefab);

                // Load the corresponding scene
                LoadScene(mapping.sceneName);
                return;
            }
        }

        // If prefab was not found in the mappings, log an error
        Debug.LogError("Prefab not found in the mapping list!");
    }

    // Method to load a scene
    private void LoadScene(string sceneName)
    {
        // Asynchronously load the scene
        SceneManager.LoadScene(sceneName);
    }

    // Accessor for the singleton instance
    public static PersistentObjectManager Instance
    {
        get
        {
            return instance;
        }
    }
}
