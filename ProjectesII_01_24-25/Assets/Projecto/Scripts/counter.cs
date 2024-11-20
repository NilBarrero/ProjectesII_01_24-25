using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    // Referencias a los anuncios (esto no es necesario si se eliminan mediante el clic)
    [SerializeField] public GameObject Ad1;
    [SerializeField] public GameObject Ad2; 
    [SerializeField] public GameObject Ad3;
    [SerializeField] public GameObject Ad4;

    // Método para destruir un anuncio específico
    public void CloseSpecificAd(GameObject adToClose)
    {
        if (adToClose != null)
        {
            Destroy(adToClose);  // Destruye el objeto que se pasa como parámetro
        }
        else
        {
            Debug.LogError("El objeto a destruir es null");
        }
    }
}
