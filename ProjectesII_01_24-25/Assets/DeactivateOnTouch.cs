using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnTouch : MonoBehaviour
{
    public GameObject document;
    public bool hasBeenActivated = false;
    public Vector3 teleport;
    private bool hasBeenClicked = false; // Bandera para controlar el clic

    // Start is called before the first frame update
    void Start()
    {
        // Asegurarse de no resetear el estado de 'hasBeenActivated' al iniciar
        // si no es necesario (No reiniciar aquí).
    }

    // Update is called once per frame
    void Update()
    {
        // Puedes agregar un control adicional si necesitas hacer algo cuando 'hasBeenActivated' sea true.

    }

    private void OnMouseDown()
    {
          
            hasBeenActivated = true;  // Establece el valor como true al hacer clic.
            
            document.transform.position = teleport;
            Debug.Log("hasBeenActivated = true");

            // Si es necesario, desactivar el Collider después de un clic
            // GetComponent<Collider>().enabled = false; // Desactiva el collider para evitar más clics
        
    }
}

