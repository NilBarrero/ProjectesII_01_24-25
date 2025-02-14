using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LeerNumeros : MonoBehaviour
{
    public string ruta;

    void Start()
    {
        // Establecer la ruta del archivo
        ruta = Application.persistentDataPath + "/Path.txt";

        // Llamamos a la función para leer los números
        List<int> numbers = LeerNumerosDesdeArchivo();

        // Imprimir los números leídos
        foreach (int numero in numbers)
        {
            Debug.Log("Número leído: " + numero);
        }
    }

    List<int> LeerNumerosDesdeArchivo()
    {
        List<int> numerosLeidos = new List<int>();

        // Verificar si el archivo existe
        if (File.Exists(ruta))
        {
            // Leer todo el contenido del archivo
            string contenido = File.ReadAllText(ruta);

            // Dividir el contenido en partes usando el espacio como delimitador
            string[] numerosComoString = contenido.Split(' ');

            // Recorrer cada parte y convertir a entero
            foreach (string numeroStr in numerosComoString)
            {
                // Ignorar espacios vacíos o líneas vacías
                if (string.IsNullOrWhiteSpace(numeroStr)) continue;

                // Intentar convertir el string a número entero
                if (int.TryParse(numeroStr, out int numero))
                {
                    numerosLeidos.Add(numero); // Agregar el número a la lista
                }
                else
                {
                    Debug.LogWarning("No se pudo convertir a número: " + numeroStr);
                }
            }
        }
        else
        {
            Debug.LogError("El archivo no existe en la ruta especificada.");
        }

        return numerosLeidos;
    }
}
