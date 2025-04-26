using UnityEngine;

public class ControlDeColisiones : MonoBehaviour
{
    // La capa "NoColision" que contiene los objetos con los que no queremos colisionar
    public string capaNoColision = "NoColision";

    void Start()
    {
        // Obtener el n�mero de capa de "NoColision"
        int layerNoColision = LayerMask.NameToLayer(capaNoColision);

        // Obtener el Collider 2D del GameObject que tiene este script
        Collider2D colliderDeEsteObjeto = GetComponent<Collider2D>();

        // Asegurarnos de que el Collider de este GameObject interact�e con los dem�s objetos del escenario
        if (colliderDeEsteObjeto != null)
        {
            // Obtener todos los objetos de la capa "NoColision" en la escena
            GameObject[] objetosNoColision = GameObject.FindGameObjectsWithTag(capaNoColision);

            // Iterar sobre todos los objetos de la capa "NoColision" y desactivar la colisi�n con este GameObject
            foreach (GameObject objeto in objetosNoColision)
            {
                // Asegurarnos de que solo ignoramos colisiones con los objetos de la capa "NoColision"
                if (objeto.layer == layerNoColision)
                {
                    Collider2D colliderDelObjeto = objeto.GetComponent<Collider2D>();

                    // Verificar que el objeto tiene un Collider2D antes de intentar ignorar la colisi�n
                    if (colliderDelObjeto != null)
                    {
                        // Ignorar la colisi�n entre este GameObject y los objetos de la capa "NoColision"
                        Physics2D.IgnoreCollision(colliderDeEsteObjeto, colliderDelObjeto, true);
                    }
                }
            }
        }
    }
}



