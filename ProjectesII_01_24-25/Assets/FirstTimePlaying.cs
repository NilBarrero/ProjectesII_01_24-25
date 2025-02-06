using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Collections;
public class CambiarTextoArchivo : MonoBehaviour
{
    // Ruta del archivo de texto
    public string rutaArchivo = "Assets/Projecto/TXT/EntryLog.txt";
    public string tutorial = "Tutorial";

    public float tiempoEspera = 15f;

    void Start()
    {
        // Llamamos a la corutina cuando el juego comienza
        StartCoroutine(EsperarYRealizarAccion(tiempoEspera));
    }

    // Corutina que espera "x" segundos y luego ejecuta la acción
    private IEnumerator EsperarYRealizarAccion(float segundos)
    {
        // Esperamos la cantidad de segundos especificada
        yield return new WaitForSeconds(segundos);

        // Realizamos la acción después de esperar
        ComprobarYReemplazarTexto();
    }

    void ComprobarYReemplazarTexto()
    {
        // Verificar si el archivo existe
        if (File.Exists(rutaArchivo))
        {
            // Leer todo el contenido del archivo
            string contenido = File.ReadAllText(rutaArchivo);

            // Comprobar si el contenido contiene la palabra o frase que quieres reemplazar
            if (contenido.Contains("0"))
            {
                // Reemplazar el texto "X" por "NuevoTexto"
                string nuevoContenido = contenido.Replace("0", "1");

                // Guardar el archivo con el nuevo contenido
                File.WriteAllText(rutaArchivo, nuevoContenido);

                Debug.Log("Texto reemplazado con éxito.");
                SceneManager.LoadScene(tutorial);
            }
            else
            {
                Debug.Log("No se encontró el texto a reemplazar.");
            }
        }
        else
        {
            Debug.LogError("El archivo no existe en la ruta especificada.");
        }
    }
}

