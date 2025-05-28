using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarPopup : MonoBehaviour
{
    [Tooltip("Destroy object when clicking (Normally the Parent)")]
    public GameObject objetoADestruir;

    public void Destruir()
    {
        if (objetoADestruir != null)
        {
            Destroy(objetoADestruir);
        }
        else
        {
            Debug.LogWarning("Object not asigned when destroying object");
        }
    }

}