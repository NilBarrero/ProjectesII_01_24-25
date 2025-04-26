using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class UnlockingPath : MonoBehaviour
{
    public string ruta;
    public int currentSceneID;
    public bool startOfJob = false;
    // Start is called before the first frame update
    void Start()
    {
        // Set the file path
        ruta = Application.persistentDataPath + "/Path.txt";

        // Get the ID of the current scene
        currentSceneID = SceneManager.GetActiveScene().buildIndex;

        // Call the function to handle writing and check for duplicates
        if (startOfJob)
        {
            File.WriteAllText(ruta, string.Empty);
        }
        VerificarNumerosRepetidos();
    }

    // Function to check for duplicate numbers and write the scene ID
    void VerificarNumerosRepetidos()
    {
        if (!File.Exists(ruta))
        {
            File.Create(ruta).Close();
        }
        if (File.Exists(ruta))
        {
            // Read all content from the file
            string contenido = File.ReadAllText(ruta);

            // Split the content into numbers using space as a delimiter
            string[] numerosComoString = contenido.Split(' ');

            // Create a HashSet to check for duplicates
            HashSet<int> numerosVistos = new HashSet<int>();

            // Loop through the numbers from the file
            foreach (string numeroStr in numerosComoString)
            {
                // Ignore any empty entries that may arise from extra spaces at the end
                if (string.IsNullOrWhiteSpace(numeroStr)) continue;

                // Convert the string to an integer
                int numero = int.Parse(numeroStr);

                // Check if we have already seen this number
                numerosVistos.Add(numero);
            }

            // Check if the current scene number is already in the HashSet
            if (!numerosVistos.Contains(currentSceneID))
            {
                // If it's not, add it to the file
                File.AppendAllText(ruta, currentSceneID + " ");
                Debug.Log("Scene number added: " + currentSceneID);
            }
            else
            {
                Debug.Log("The scene is already registered in the file.");
            }
        }
        else
        {
            // If the file does not exist, create it and add the scene number
            File.AppendAllText(ruta, currentSceneID + " ");
            Debug.Log("The file did not exist, it has been created and the scene number has been added: " + currentSceneID);
        }
    }
}
