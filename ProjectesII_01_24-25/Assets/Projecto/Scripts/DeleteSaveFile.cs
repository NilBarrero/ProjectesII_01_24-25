using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class DeteleSaveFile : MonoBehaviour
{
    public string ruta = "Assets/Projecto/SaveFileFolder/SaveFile.txt";

    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(ruta))
        {
            Debug.LogError("File Doesn't Exist");
        }
        delete();
    }

    void delete()
    {

        File.WriteAllText(ruta, "");
    }
}
