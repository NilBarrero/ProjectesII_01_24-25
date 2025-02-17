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

        // Llamar a la funci�n para manejar la escritura y verificar duplicados
        VerificarNumerosRepetidos();
    }

    // Funci�n para verificar n�meros repetidos y escribir el ID de la escena
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

            // Dividir el contenido en n�meros usando espacio como delimitador
            string[] numerosComoString = contenido.Split(' ');

            // Crear un HashSet para verificar duplicados
            HashSet<int> numerosVistos = new HashSet<int>();

            // Recorrer los n�meros del archivo
            foreach (string numeroStr in numerosComoString)
            {
                // Ignorar vac�os que puedan surgir de espacios extra al final
                if (string.IsNullOrWhiteSpace(numeroStr)) continue;

                // Convertir el n�mero a entero
                int numero = int.Parse(numeroStr);

                // Verificar si ya vimos este n�mero
                numerosVistos.Add(numero);
            }

            // Verificar si el n�mero de la escena actual ya est� en el HashSet
            if (!numerosVistos.Contains(currentSceneID))
            {
                // Si no est�, lo agregamos al archivo
                File.AppendAllText(ruta, currentSceneID + " ");
                Debug.Log("N�mero de la escena a�adido: " + currentSceneID);
            }
            else
            {
                Debug.Log("La escena ya est� registrada en el archivo.");
            }
        }
        else
        {
            // Si el archivo no existe, crearlo y agregar el n�mero de la escena
            File.AppendAllText(ruta, currentSceneID + " ");
            Debug.Log("El archivo no exist�a, se ha creado y se ha a�adido el n�mero de la escena: " + currentSceneID);
        }
    }
}

