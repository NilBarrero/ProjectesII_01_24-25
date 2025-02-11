using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveFIleReadAndWrite : MonoBehaviour
{
    Scene currentScene = SceneManager.GetActiveScene();
    public string rutaArchivo = "Assets/Projecto/SaveFileFolder/SaveFile.txt";
     
    // Start is called before the first frame update
    void Start()
    {
        string currentSceneIndex = currentScene.name;
        if (!File.Exists(rutaArchivo))
        {
            Debug.LogError("File Doesn't Exist");
        }
        string contenido = currentSceneIndex;
        write(contenido);
    }

    void write(string contenido)
    {

            File.WriteAllText(rutaArchivo, contenido);
    }
}
