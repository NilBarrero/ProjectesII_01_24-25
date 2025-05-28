using UnityEngine;

public class ControlDeColisiones : MonoBehaviour
{
    // The "NoColision" layer that contains the objects we don't want to collide with
    public string capaNoColision = "NoColision";

    void Start()
    {
        int layerNoColision = LayerMask.NameToLayer(capaNoColision);

        Collider2D colliderDeEsteObjeto = GetComponent<Collider2D>();

        if (colliderDeEsteObjeto != null)
        {
            GameObject[] objetosNoColision = GameObject.FindGameObjectsWithTag(capaNoColision);

            
            foreach (GameObject objeto in objetosNoColision)
            {
                if (objeto.layer == layerNoColision)
                {
                    Collider2D colliderDelObjeto = objeto.GetComponent<Collider2D>();

                    if (colliderDelObjeto != null)
                    {
                        Physics2D.IgnoreCollision(colliderDeEsteObjeto, colliderDelObjeto, true);
                    }
                }
            }
        }
    }
}

