using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class UnlockingPath : MonoBehaviour
{
    public string ruta;
    public int currentSceneID;

    // Start is called before the first frame update
    void Start()
    {
        // Establecer la ruta al archivo
        ruta = Application.persistentDataPath + "/Path.txt";

        // Obtener el ID de la escena actual
        currentSceneID = SceneManager.GetActiveScene().buildIndex;

        // Llamar a la función para manejar la escritura y verificar duplicados
        VerificarNumerosRepetidos();
    }

    // Función para verificar números repetidos y escribir el ID de la escena
    void VerificarNumerosRepetidos()
    {
        if (!File.Exists(ruta))
        {
            File.Create(ruta).Close();
        }
        if (File.Exists(ruta))
        {
            // Leer todo el contenido del archivo
            string contenido = File.ReadAllText(ruta);

            // Dividir el contenido en números usando espacio como delimitador
            string[] numerosComoString = contenido.Split(' ');

            // Crear un HashSet para verificar duplicados
            HashSet<int> numerosVistos = new HashSet<int>();

            // Recorrer los números del archivo
            foreach (string numeroStr in numerosComoString)
            {
                // Ignorar vacíos que puedan surgir de espacios extra al final
                if (string.IsNullOrWhiteSpace(numeroStr)) continue;

                // Convertir el número a entero
                int numero = int.Parse(numeroStr);

                // Verificar si ya vimos este número
                numerosVistos.Add(numero);
            }

            // Verificar si el número de la escena actual ya está en el HashSet
            if (!numerosVistos.Contains(currentSceneID))
            {
                // Si no está, lo agregamos al archivo
                File.AppendAllText(ruta, currentSceneID + " ");
                Debug.Log("Número de la escena añadido: " + currentSceneID);
            }
            else
            {
                Debug.Log("La escena ya está registrada en el archivo.");
            }
        }
        else
        {
            // Si el archivo no existe, crearlo y agregar el número de la escena
            File.AppendAllText(ruta, currentSceneID + " ");
            Debug.Log("El archivo no existía, se ha creado y se ha añadido el número de la escena: " + currentSceneID);
        }
    }
}

