using UnityEngine;

public class ControlDeColisiones : MonoBehaviour
{
    // The "NoColision" layer that contains the objects we don't want to collide with
    public string capaNoColision = "NoColision";

    void Start()
    {
        // Get the layer number of "NoColision"
        int layerNoColision = LayerMask.NameToLayer(capaNoColision);

        // Get the 2D Collider of the GameObject that has this script
        Collider2D colliderDeEsteObjeto = GetComponent<Collider2D>();

        // Ensure that the Collider of this GameObject interacts with other objects in the scene
        if (colliderDeEsteObjeto != null)
        {
            // Get all objects with the "NoColision" tag in the scene
            GameObject[] objetosNoColision = GameObject.FindGameObjectsWithTag(capaNoColision);

            // Iterate over all objects with the "NoColision" tag and disable collisions with this GameObject
            foreach (GameObject objeto in objetosNoColision)
            {
                // Ensure we are only ignoring collisions with objects in the "NoColision" layer
                if (objeto.layer == layerNoColision)
                {
                    Collider2D colliderDelObjeto = objeto.GetComponent<Collider2D>();

                    // Check if the object has a Collider2D before attempting to ignore the collision
                    if (colliderDelObjeto != null)
                    {
                        // Ignore the collision between this GameObject and the objects in the "NoColision" layer
                        Physics2D.IgnoreCollision(colliderDeEsteObjeto, colliderDelObjeto, true);
                    }
                }
            }
        }
    }
}

